--[[
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

]]

resource_manifest_version '44febabe-d386-4d18-afbe-5e627f4af937'
client_script 'mz_npc-spawn-control.net.dll';

--	Konfig:
--	0 = Dekaktiviert 
--	1 = Aktiviert

-- ai_ped_spawning -> Steuert das Spawnen von Bots
ai_ped_spawning '0'
-- ai_car_spawning -> Steuert das Spawnen von AI-Fahrzeugen
ai_car_spawning '0' 
-- parked_ai_car_spawning -> Spawnen von zufälligen Fahrzeugen am Straßenrand
parked_ai_car_spawning '0' 
-- garbage_trucks_spawning -> Steuern der nächtliche Müllentsorgung
garbage_trucks_spawning '0'
-- random_boats_spawning -> Steuerung von Fahrendeen Booten in der Bucht
random_boats_spawning '0'
-- random_trains_spawning -> Funktioniert solbald Züge in FiveM synchronisiert werden
random_trains_spawning '0'
-- police_ignore_player -> Wenn 1 ignoriert die Polizei den Spieler
police_ignore_player '0'

--Dispatch-Services:
--Mehr Informationen zu Dispatch-Services: https://gta-fivem.org/forum/index.php?thread/77-dispatch-services/&postID=199#post199
--PoliceAutomobile 
enable_dispatch_service_01 '0'
--PoliceHelicopter 
enable_dispatch_service_02 '0'
--FireDepartment 
enable_dispatch_service_03 '0'
--SwatAutomobile
enable_dispatch_service_04 '0'
--AmbulanceDepartment
enable_dispatch_service_05 '0'
--PoliceRiders
enable_dispatch_service_06 '0'
--PoliceVehicleRequest
enable_dispatch_service_07 '0'
--PoliceRoadBlock
enable_dispatch_service_08 '0'
--PoliceAutomobileWaitPulledOver
enable_dispatch_service_09 '0'
--PoliceAutomobileWaitCruising
enable_dispatch_service_10 '0'
--Gangs
enable_dispatch_service_11 '0'
--SwatHelicopter
enable_dispatch_service_12 '0'
--PoliceBoat
enable_dispatch_service_13 '0'
--ArmyVehicle
enable_dispatch_service_14 '0'
--BikerBackup
enable_dispatch_service_15 '0'

--Fortgeschrittene Konfiguration:
-- delete_all_entities_on_start_up -> Löscht beim Starten alle nicht persistenten Peds und Fahrzeuge
delete_all_entities_on_start_up '1'
--delete_all_non_persistent_entities -> Löscht alle nicht persistenten Fahrzeuge um das Spawnen von Random fahrzeugen zu vermeiden, kann jedoch bei Verwendung schlechter Plugins zu Fehlern führen! 
delete_all_non_persistent_entities '1'