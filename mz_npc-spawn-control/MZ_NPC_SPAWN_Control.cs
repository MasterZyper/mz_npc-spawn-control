/*
MZ-NPC-Spawn-Control, controls the spawning of random NPCs in FiveM
Copyright (C) 27.08.2019  MasterZyper 🐦
Contact: masterzyper@reloaded-server.de
You like to get a FiveM-Server? 
Visit ZapHosting*: https://zap-hosting.com/a/17444fc14f5749d607b4ca949eaf305ed50c0837

Support us on Patreon: https://www.patreon.com/gtafivemorg

For help with this Script visit: https://gta-fivem.org/

This program is free software; you can redistribute it and/or modify it under the terms of the 
GNU General Public License as published by the Free Software Foundation; either version 3 of 
the License, or (at your option) any later version.
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
See the GNU General Public License for more details.
You should have received a copy of the GNU General Public License along with this program; 
if not, see <http://www.gnu.org/licenses/>.

*Affiliate-Link: Euch entstehen keine Kosten oder Nachteile. Kauf über diesen Link erwirtschaftet eine kleine prozentuale Provision für mich.

*/

using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mz_npc_spawn_control
{
    public class MZ_NPC_SPAWN_Control : BaseScript
    {
        //Public Variables
        private bool Exception = false;
        //Variables from CFG
        bool CFG_AiPedSpawning = true;
        bool CFG_AiCarSpawning = true;
        bool CFG_ParkedAiCarSpawning = true;
        bool CFG_GarbageTrucks = true;
        bool CFG_RandomBoats = true;
        bool CFG_RandomTrains = true;
        bool CFG_PoliceIgnorePlayer = true;
        bool CFG_Dispatch_01 = true;
        bool CFG_Dispatch_02 = true;
        bool CFG_Dispatch_03 = true;
        bool CFG_Dispatch_04 = true;
        bool CFG_Dispatch_05 = true;
        bool CFG_Dispatch_06 = true;
        bool CFG_Dispatch_07 = true;
        bool CFG_Dispatch_08 = true;
        bool CFG_Dispatch_09 = true;
        bool CFG_Dispatch_10 = true;
        bool CFG_Dispatch_11 = true;
        bool CFG_Dispatch_12 = true;
        bool CFG_Dispatch_13 = true;
        bool CFG_Dispatch_14 = true;
        bool CFG_Dispatch_15 = true;
        bool DeleteAllEntities = false;
        bool CFG_DeleteAllNonPersistentEntities = false;

        public MZ_NPC_SPAWN_Control()
        {
            string resource_name = API.GetCurrentResourceName();
            string resource_author = "MasterZyper";
            Debug.Write($"{resource_name} by {resource_author} started loading");
            //Prepare
            try
            {
                CFG_AiPedSpawning = Convert.ToBoolean(Convert.ToInt32(API.GetResourceMetadata(resource_name, "ai_ped_spawning", 0)));
                CFG_AiCarSpawning = Convert.ToBoolean(Convert.ToInt32(API.GetResourceMetadata(resource_name, "ai_car_spawning", 0)));
                CFG_ParkedAiCarSpawning = Convert.ToBoolean(Convert.ToInt32(API.GetResourceMetadata(resource_name, "parked_ai_car_spawning", 0)));
                CFG_GarbageTrucks = Convert.ToBoolean(Convert.ToInt32(API.GetResourceMetadata(resource_name, "garbage_trucks_spawning", 0)));
                CFG_RandomBoats = Convert.ToBoolean(Convert.ToInt32(API.GetResourceMetadata(resource_name, "random_boats_spawning", 0)));
                CFG_RandomTrains = Convert.ToBoolean(Convert.ToInt32(API.GetResourceMetadata(resource_name, "random_trains_spawning", 0)));
                CFG_PoliceIgnorePlayer = Convert.ToBoolean(Convert.ToInt32(API.GetResourceMetadata(resource_name, "police_ignore_player", 0)));
                CFG_Dispatch_01 = Convert.ToBoolean(Convert.ToInt32(API.GetResourceMetadata(resource_name, "enable_dispatch_service_01", 0)));
                CFG_Dispatch_02 = Convert.ToBoolean(Convert.ToInt32(API.GetResourceMetadata(resource_name, "enable_dispatch_service_02", 0)));
                CFG_Dispatch_03 = Convert.ToBoolean(Convert.ToInt32(API.GetResourceMetadata(resource_name, "enable_dispatch_service_03", 0)));
                CFG_Dispatch_04 = Convert.ToBoolean(Convert.ToInt32(API.GetResourceMetadata(resource_name, "enable_dispatch_service_04", 0)));
                CFG_Dispatch_05 = Convert.ToBoolean(Convert.ToInt32(API.GetResourceMetadata(resource_name, "enable_dispatch_service_05", 0)));
                CFG_Dispatch_06 = Convert.ToBoolean(Convert.ToInt32(API.GetResourceMetadata(resource_name, "enable_dispatch_service_06", 0)));
                CFG_Dispatch_07 = Convert.ToBoolean(Convert.ToInt32(API.GetResourceMetadata(resource_name, "enable_dispatch_service_07", 0)));
                CFG_Dispatch_08 = Convert.ToBoolean(Convert.ToInt32(API.GetResourceMetadata(resource_name, "enable_dispatch_service_08", 0)));
                CFG_Dispatch_09 = Convert.ToBoolean(Convert.ToInt32(API.GetResourceMetadata(resource_name, "enable_dispatch_service_09", 0)));
                CFG_Dispatch_10 = Convert.ToBoolean(Convert.ToInt32(API.GetResourceMetadata(resource_name, "enable_dispatch_service_10", 0)));
                CFG_Dispatch_11 = Convert.ToBoolean(Convert.ToInt32(API.GetResourceMetadata(resource_name, "enable_dispatch_service_11", 0)));
                CFG_Dispatch_12 = Convert.ToBoolean(Convert.ToInt32(API.GetResourceMetadata(resource_name, "enable_dispatch_service_12", 0)));
                CFG_Dispatch_13 = Convert.ToBoolean(Convert.ToInt32(API.GetResourceMetadata(resource_name, "enable_dispatch_service_13", 0)));
                CFG_Dispatch_14 = Convert.ToBoolean(Convert.ToInt32(API.GetResourceMetadata(resource_name, "enable_dispatch_service_14", 0)));
                CFG_Dispatch_15 = Convert.ToBoolean(Convert.ToInt32(API.GetResourceMetadata(resource_name, "enable_dispatch_service_15", 0)));
                DeleteAllEntities = Convert.ToBoolean(Convert.ToInt32(API.GetResourceMetadata(resource_name, "delete_all_entities_on_start_up", 0)));
                CFG_DeleteAllNonPersistentEntities = Convert.ToBoolean(Convert.ToInt32(API.GetResourceMetadata(resource_name, "delete_all_non_persistent_entities", 0)));
            }
            catch (FormatException e)
            {
                Debug.Write($"Fatal ERROR while loading config of {resource_name}");
                Debug.Write($"Exception-Message: {e.Message}");
                Exception = true;
            }
            catch (OverflowException e)
            {
                Debug.Write($"Fatal ERROR while loading config of {resource_name}");
                Debug.Write($"Exception-Message: {e.Message}");
                Exception = true;
            }
            if (DeleteAllEntities)
            {
                DeleteAllPedsAndVehicles();
            }
            //set static values
            API.SetGarbageTrucks(CFG_GarbageTrucks);
            API.SetRandomBoats(CFG_RandomBoats);
            API.SetRandomTrains(CFG_RandomTrains);
            if (CFG_PoliceIgnorePlayer)
            {
                API.SetPoliceIgnorePlayer(Game.Player.Handle, true);
                API.SetDispatchCopsForPlayer(Game.Player.Handle, false);
            }
            else
            {
                API.SetPoliceIgnorePlayer(Game.Player.Handle, false);
                API.SetDispatchCopsForPlayer(Game.Player.Handle, true);
            }
            API.EnableDispatchService(1, CFG_Dispatch_01);
            API.EnableDispatchService(2, CFG_Dispatch_02);
            API.EnableDispatchService(3, CFG_Dispatch_03);
            API.EnableDispatchService(4, CFG_Dispatch_04);
            API.EnableDispatchService(5, CFG_Dispatch_05);
            API.EnableDispatchService(6, CFG_Dispatch_06);
            API.EnableDispatchService(7, CFG_Dispatch_07);
            API.EnableDispatchService(8, CFG_Dispatch_08);
            API.EnableDispatchService(9, CFG_Dispatch_09);
            API.EnableDispatchService(10, CFG_Dispatch_10);
            API.EnableDispatchService(11, CFG_Dispatch_11);
            API.EnableDispatchService(12, CFG_Dispatch_12);
            API.EnableDispatchService(13, CFG_Dispatch_13);
            API.EnableDispatchService(14, CFG_Dispatch_14);
            API.EnableDispatchService(15, CFG_Dispatch_15);
            if (!Exception)
            {
                Debug.Write($"{resource_name} successful started");
                if (!CFG_AiCarSpawning)
                {
                    Tick += DisableVehicles;
                    if (CFG_DeleteAllNonPersistentEntities)
                    {
                        Tick += DeleteNonPersistentEntities;
                    }
                }
            }
        }
        private void DeleteAllPedsAndVehicles()
        {
            foreach (Vehicle veh in World.GetAllVehicles())
            {
                if (veh != null)
                {
                    if (!veh.IsPersistent)
                    {
                        veh.Delete();
                    }
                }
            }
            foreach (Ped ped in World.GetAllPeds())
            {
                if (ped != null)
                {
                    if (!ped.IsPersistent)
                    {
                        if (!ped.IsPlayer)
                        {
                            ped.Delete();
                        }
                    }
                }
            }
        }
        private async Task DeleteNonPersistentEntities()
        {
            DeleteAllPedsAndVehicles();
            await Delay(50);
        }
        private async Task DisableVehicles()
        {
            if (!Exception)
            {
                if (CFG_AiCarSpawning)
                {
                    API.SetVehicleDensityMultiplierThisFrame(1.5f);
                    API.SetRandomVehicleDensityMultiplierThisFrame(1.5f);
                }
                else
                {
                    API.SetFarDrawVehicles(false);
                    API.SetVehicleDensityMultiplierThisFrame(0f);
                    API.SetRandomVehicleDensityMultiplierThisFrame(0f);
                }
                if (CFG_ParkedAiCarSpawning)
                {
                    API.SetParkedVehicleDensityMultiplierThisFrame(2.0f);
                }
                else
                {
                    API.SetParkedVehicleDensityMultiplierThisFrame(0.0f);
                }
                if (CFG_AiPedSpawning)
                {
                    API.SetPedDensityMultiplierThisFrame(1.5f);
                    API.SetScenarioPedDensityMultiplierThisFrame(1.5f, 1.5f);
                }
                else
                {
                    API.SetPedDensityMultiplierThisFrame(0.0f);
                    API.SetScenarioPedDensityMultiplierThisFrame(0.0f, 0.0f);
                }
                if (CFG_PoliceIgnorePlayer)
                {
                    API.DisablePoliceReports();
                }
            }
            else
            {
                await Delay(500);
            }
        }
    }
}
