using ESDLang.Adapter;
using ESDLang.Doc;
using ESDLang.EzSemble;
using SoulsFormats;

namespace FogWallNS
{
	public class PreDefinedStates
	{
		public ESDL.State create_state_zero(long id, long target)
		{
			ESDL.Condition condition = new();
			condition.TargetState = target;
			ESDL.State state = new();
			state.Conditions.Add(condition);
			state.Name = $"State{id}-0";
			state.ID = 0;
			return state;
		}

		public ESDL.State create_state_one(long id)
		{
			ESDL.State state = new();
			state.EntryScript = "RestartMachine();";
			state.Name = $"State{id}-1";
			state.ID = 1;
			return state;
		}

		public ESDL.State create_state_two(long id,
			int warp_obj_inst_id = 10020419,
			int event_loc = 141,
			int map_id = 10310000
		)
		{
			ESDL.Condition condition = new();
			condition.Evaluator = "#B9 != #BA";
			condition.PassScript = "";
			condition.TargetState = 1;
			ESDL.State state = new();
			state.EntryScript = $"6:2147483146({warp_obj_inst_id}, {event_loc}, {map_id});";
			state.Conditions.Add(condition);
			state.Name = $"State{id}-2";
			state.ID = 2;
			return state;
		}

		public Dictionary<long, ESDL.State> create_state(long id,
			int warp_obj_inst_id, int event_loc, int map_id)
		{
			Dictionary<long, ESDL.State> states = new();
			states[0] = create_state_zero(id, 2);
			states[1] = create_state_one(id);
			states[2] = create_state_two(id, warp_obj_inst_id, event_loc, map_id);
			return states;
		}

		public ESDL.State create_state_zero2147483146(long id)
		{
			ESDL.Condition condition = new();
			condition.Evaluator = "#B9 != #BA";
			condition.PassScript = "";
			condition.TargetState = 1;
			ESDL.State state = new();
			state.Conditions.Add(condition);
			state.Name = $"State{id}-0";
			state.EntryScript = "6:2147483145(StateGroupArg[0]);";
			state.ID = 0;
			return state;
		}

		public ESDL.State create_state_one2147483146(long id)
		{
			ESDL.Condition condition = new();
			condition.Evaluator = "#B9 != #BA";
			condition.PassScript = "";
			condition.TargetState = 2;
			ESDL.State state = new();
			state.Conditions.Add(condition);
			state.EntryScript = "6:2147483144(StateGroupArg[1], StateGroupArg[0], StateGroupArg[2]);";
			state.Name = $"State{id}-1";
			state.ID = 1;
			return state;
		}

		public ESDL.State create_state_two2147483146(long id)
		{
			ESDL.Condition condition = new();
			condition.Evaluator = "1";
			condition.PassScript = "7:-1(0);";
			condition.TargetState = 1;
			ESDL.State state = new();
			state.Conditions.Add(condition);
			state.Name = $"State{id}-2";
			state.ID = 2;
			return state;
		}

		public Dictionary<long, ESDL.State> create_state2147483146(long id)
		{
			Dictionary<long, ESDL.State> states = new();
			states[0] = create_state_zero2147483146(id);
			states[1] = create_state_one2147483146(id);
			states[2] = create_state_two2147483146(id);
			return states;
		}

		public ESDL.State create_state_zero2147483145(long id)
		{
			ESDL.Condition condition = new();
			condition.Evaluator = "ConditionGroup(0)";
			condition.PassScript = "";
			condition.TargetState = 1;
			ESDL.State state = new();
			state.Conditions.Add(condition);
			state.Name = $"State{id}-0";
			state.EntryScript = "IsObjSearched(0, StateGroupArg[0]);";
			state.ID = 0;
			return state;
		}

		public ESDL.State create_state_one2147483145(long id)
		{
			ESDL.Condition condition = new();
			condition.Evaluator = "1";
			condition.PassScript = "7:-1(0);";
			ESDL.State state = new();
			state.Conditions.Add(condition);
			state.EntryScript = "6:2147483144(StateGroupArg[1], StateGroupArg[0], StateGroupArg[2]);";
			state.Name = $"State{id}-1";
			state.ID = 1;
			return state;
		}

		public Dictionary<long, ESDL.State> create_state2147483145(long id)
		{
			Dictionary<long, ESDL.State> states = new();
			states[0] = create_state_zero2147483145(id);
			states[1] = create_state_one2147483145(id);
			return states;
		}

		public ESDL.State create_state_zero2147483144(long id)
		{
			ESDL.Condition condition = new();
			condition.Evaluator = "CutsceneWarpEnded() != 0";
			condition.PassScript = "";
			condition.TargetState = 1;
			ESDL.State state = new();
			state.Conditions.Add(condition);
			state.Name = $"State{id}-0";
			state.EntryScript = "DisableObjKeyGuide(StateGroupArg[1], 1);\nProhibitInGameMenu(1);\nProhibitPlayerOperation(1);\nSetPlayerInvincible(1);\nPlayCutsceneAndWarpToMap(0, 0, StateGroupArg[2], StateGroupArg[0], 0);";
			state.ID = 0;
			return state;
		}

		public ESDL.State create_state_one2147483144(long id)
		{
			ESDL.Condition condition = new();
			condition.Evaluator = "1";
			condition.PassScript = "7:-1(0);";
			ESDL.State state = new();
			state.Conditions.Add(condition);
			state.EntryScript = "DisableObjKeyGuide(StateGroupArg[1], 0);\nProhibitInGameMenu(0);\nProhibitPlayerOperation(0);\nSetPlayerInvincible(0);";
			state.Name = $"State{id}-1";
			state.ID = 1;
			return state;
		}

		public Dictionary<long, ESDL.State> create_state2147483144(long id)
		{
			Dictionary<long, ESDL.State> states = new();
			states[0] = create_state_zero2147483144(id);
			states[1] = create_state_one2147483144(id);
			return states;
		}

        ESDL.Condition assert_condition_group(int group, long target)
        {
            ESDL.Condition condition = new();
            condition.Evaluator = $"ConditionGroup({group})";
            condition.TargetState = target;
            return condition;
        }

        ESDL.Condition true_condition(long target)
        {
            ESDL.Condition condition = new();
            condition.Evaluator = "1";
            condition.TargetState = target;
            return condition;
        }


        ESDL.State create_state_zero2147483141(long id, int global_flag)
        {
            ESDL.State state = new();
            ESDL.Condition c1 = assert_condition_group(0, 1);
            ESDL.Condition c2 = true_condition(2);
            state.Conditions.Add(c1);
            state.Conditions.Add(c2);
            state.Name = $"State{id}-0";
            state.EntryScript = $"DisableObjKeyGuide(StateGroupArg[0], 1);\nCompareEventFlag(0, {global_flag}, 1);";
            state.ID = 0;
            return state;
        }

        ESDL.State create_state_one2147483141(long id)
        {
            ESDL.State state = new();
            ESDL.Condition c1 = B9neBA(3);
            state.Conditions.Add(c1);
            state.Name = $"State{id}-1";
            state.EntryScript = $"6:2147483144(StateGroupArg[1], StateGroupArg[0], StateGroupArg[2]);";
            state.ID = 1;
            return state;
        }

        ESDL.State create_state_two2147483141(long id, int msg_id)
        {
            ESDL.State state = new();
            ESDL.Condition c1 = true_condition(3);
            state.Conditions.Add(c1);
            state.Name = $"State{id}-2";
            state.EntryScript = $"DisplayEventMessage({msg_id}, 0, 0, 0);";
            state.ID = 2;
            return state;
        }

        ESDL.State create_state_three2147483141(long id)
        {
            ESDL.State state = new();
            ESDL.Condition c1 = new();
            c1.Evaluator = "EventMessageDisplay() != 1";
            state.Conditions.Add(c1);
            state.Name = $"State{id}-3";
            state.ID = 3;
            return state;
        }

        ESDL.State create_state_four2147483141(long id)
        {
            ESDL.State state = new();
            ESDL.Condition c1 = new();
            c1.Evaluator = "1";
            c1.PassScript = "7:-1(0);";
            state.Conditions.Add(c1);
            state.EntryScript = "DisableObjKeyGuide(StateGroupArg[0], 0);";
            state.Name = $"State{id}-4";
            state.ID = 4;
            return state;
        }

        public Dictionary<long, ESDL.State> create_state2147483141(long id, int global_flag, int msg_id)
		{
            Dictionary<long, ESDL.State> states = new();
            states[0] = create_state_zero2147483141(id, global_flag);
            states[1] = create_state_one2147483141(id);
            states[2] = create_state_two2147483141(id, msg_id);
            states[3] = create_state_three2147483141(id);
            states[4] = create_state_four2147483141(id);
			return states;
        }

        public Dictionary<long, ESDL.State> create_state2147483142(long id) 
        {
            Dictionary<long, ESDL.State> states = new();
            states[0] = create_state_zero2147483142(id);
            states[1] = create_state_one2147483142(id);
            states[2] = create_state_two2147483142(id);
            states[3] = create_state_three2147483142(id);
            return states;
        }

        ESDL.State create_state_zero2147483143(long id)
        {
            ESDL.State state = new();
            ESDL.Condition c0 = new();
            c0.Evaluator = "ConditionGroup(0)";
            c0.TargetState = 1;
            state.Conditions.Add(c0);
            state.Name = $"State{id}-3";
            state.EntryScript = $"IsEventBossKill(0, StateGroupArg[0], 0, 1);";
            state.ID = 0;
            return state;
        }

        ESDL.State create_state_one2147483143(long id)
        {
            ESDL.State state = new();
            ESDL.Condition c0 = new();
            c0.Evaluator = "1";
            c0.PassScript = "7:-1(0);";
            state.Conditions.Add(c0);
            state.Name = $"State{id}-3";
            state.EntryScript = $"IsEventBossKill(0, StateGroupArg[0], 0, 1);";
            state.ID = 1;
            return state;
        }

        public Dictionary<long, ESDL.State>  create_state2147483143(long id)
        {
            Dictionary<long, ESDL.State> states = new();
            states[0] = create_state_zero2147483143(id);
            states[1] = create_state_one2147483143(id);
            return states;
        }

        ESDL.State create_ship_check_state_one(long id, int global_flag)
        {
            ESDL.Condition condition = new();
            condition.Evaluator = "ConditionGroup(0)";
            ESDL.State state = new();
            state.Conditions.Add(condition);
            state.EntryScript = $"SetEventFlag({global_flag}, 1);\nCompareEventFlag(0, {global_flag}, 1);";
            state.Name = $"State{id}-1";
            state.ID = 1;
            return state;
        }

        ESDL.State create_ship_check_state_two(long id, int ship_arrival_flag)
        {
            ESDL.State state = new();
            ESDL.Condition condition0 = new();
            condition0.Evaluator = $"GetEventFlag({ship_arrival_flag}) != 0";
            condition0.TargetState = 1;
            state.Conditions.Add(condition0);
            ESDL.Condition condition1 = new();
            condition1.Evaluator = "1";
            state.Conditions.Add(condition1);
            state.Name = $"State{id}-2";
            state.ID = 2;
            return state;
        }

        ESDL.Condition B9neBA(long target)
        {
            ESDL.Condition condition = new();
            condition.Evaluator = "#B9 != #BA";
            condition.TargetState = target;
            return condition;
        }

        ESDL.State create_ship_check_from_state_one(long id,
            int warp_obj_inst_id, int event_loc, int map_id
        )
        {
            ESDL.Condition condition = B9neBA(3);
            ESDL.State state = new();
            state.Conditions.Add(condition);
            state.EntryScript = $"6:2147483141({warp_obj_inst_id}, {event_loc}, {map_id});";
            state.Name = $"State{id}-1";
            state.ID = 1;
            return state;
        }

        ESDL.State create_ship_check_from_state_two(long id,
            int warp_obj_inst_id, int event_loc, int map_id
        )
        {
            ESDL.Condition condition = B9neBA(1);
            ESDL.State state = new();
            state.Conditions.Add(condition);
            state.EntryScript = $"6:2147483145({warp_obj_inst_id});";
            state.Name = $"State{id}-2";
            state.ID = 2;
            return state;
        }

        ESDL.State end_machine_state(long id)
        {
            ESDL.State state = new();
            state.EntryScript = "EndMachine();";
            state.ID = id;
            return state;
        }

        ESDL.State restart_machine_state(long id)
        {
            ESDL.State state = new();
            state.EntryScript = "RestartMachine();";
            state.ID = id;
            return state;
        }

        // for wharf map
        public Dictionary<long, ESDL.State> create_ship_check_state(long id,
            int ship_arrival_flag, int global_flag)
        {
            Dictionary<long, ESDL.State> states = new();
            states[0] = create_state_zero(id, 2);
            states[1] = create_ship_check_state_one(id, global_flag);
            states[2] = create_ship_check_state_two(id, ship_arrival_flag);
            states[3] = end_machine_state(3);
            states[4] = restart_machine_state(4);
            return states;
        }

        // for map other than wharf
        public Dictionary<long, ESDL.State> create_ship_check_from_state(long id,
           int warp_obj_inst_id, int event_loc, int map_id
       )
        {
            Dictionary<long, ESDL.State> states = new();
            states[0] = create_state_zero(id, 2);
            states[1] = create_ship_check_from_state_one(id, warp_obj_inst_id, event_loc, map_id);
            states[2] = create_ship_check_from_state_two(id, warp_obj_inst_id, event_loc, map_id);
            states[3] = restart_machine_state(3);
            return states;
        }

        ESDL.State create_state_zero2147483142(long id)
        {
            ESDL.State state = new();
            ESDL.Condition c0 = new();
            c0.Evaluator = "1";
            c0.TargetState = 1;
            state.Conditions.Add(c0);
            state.Name = $"State{id}-0";
            state.ID = 0;
            return state;
        }


        ESDL.State create_state_one2147483142(long id)
        {
            ESDL.State state = new();
            ESDL.Condition c0 = new();
            c0.Evaluator = "GetEventFlag(StateGroupArg[0]) != 0";
            c0.TargetState = 3;
            ESDL.Condition c1 = new();
            c1.Evaluator = "1";
            c1.TargetState = 2;
            state.Conditions.Add(c0);
            state.Conditions.Add(c1);
            state.Name = $"State{id}-1";
            state.ID = 1;
            return state;
        }

        ESDL.State create_state_two2147483142(long id)
        {
            ESDL.State state = new();
            ESDL.Condition c0 = new();
            c0.Evaluator = "1";
            c0.PassScript = "7:-1(0);";
            state.Conditions.Add(c0);
            state.Name = $"State{id}-2";
            state.ID = 2;
            return state;
        }

        ESDL.State create_state_three2147483142(long id)
        {
            ESDL.State state = new();
            ESDL.Condition c0 = new();
            c0.Evaluator = "1";
            c0.PassScript = "7:-1(1);";
            state.Conditions.Add(c0);
            state.Name = $"State{id}-3";
            state.ID = 3;
            return state;
        }

        ESDL.State create_boss_back_state_zero(long id)
        {
            ESDL.State state = new();
            ESDL.Condition condition = new();
            condition.Evaluator = "1";
            condition.TargetState = 2;
            state.Conditions.Add(condition);
            state.Name = $"State{id}-0";
            state.ID = 0;
            return state;
        }


        ESDL.State create_boss_back_state_one(long id,
            int warp_obj_inst_id, int event_loc, int map_id
        )
        {
            ESDL.Condition condition = B9neBA(3);
            ESDL.State state = new();
            state.EntryScript = $"DisableObjKeyGuide({warp_obj_inst_id}, 0);\n6:2147483146({warp_obj_inst_id}, {event_loc}, {map_id});";
            state.Conditions.Add(condition);
            state.Name = $"State{id}-1";
            state.ID = 1;
            return state;
        }

        ESDL.State create_boss_back_state_two(long id,
            int warp_obj_inst_id, int event_loc, int map_id, int boss_destruction_id
        )
        {
            ESDL.State state = new();
            ESDL.Condition c1 = new();
            c1.Evaluator = "#B9 == 1";
            c1.TargetState = 1;
            ESDL.Condition c2 = new();
            c2.Evaluator = "#B9 == 0";
            c2.TargetState = 3;
            state.Conditions.Add(c1);
            state.Conditions.Add(c2);
            state.EntryScript = $"DisableObjKeyGuide({warp_obj_inst_id}, 1);\n6:2147483142({boss_destruction_id});";
            state.Name = $"State{id}-1";
            state.ID = 1;
            return state;
        }

        ESDL.State create_boss_back_state_two_2nd_impl(long id,
            int warp_obj_inst_id, int event_loc, int map_id, int boss_destruction_id
        )
        {
            ESDL.State state = new();
            ESDL.Condition c1 = B9neBA(1);
            state.Conditions.Add(c1);
            state.EntryScript = $"DisableObjKeyGuide({warp_obj_inst_id}, 1);\n6:2147483143({boss_destruction_id});";
            state.Name = $"State{id}-1";
            state.ID = 2;
            return state;
        }

        public Dictionary<long, ESDL.State> create_boss_back_fog_gate_event(long id,
            int warp_obj_inst_id, int event_loc, int map_id, int boss_destruction_id
        )
        {
            Dictionary<long, ESDL.State> states = new();
            states[0] = create_boss_back_state_zero(id);
            states[1] = create_boss_back_state_one(id, warp_obj_inst_id, event_loc, map_id);
            states[2] = create_boss_back_state_two(id, warp_obj_inst_id, event_loc, map_id, boss_destruction_id);
            states[3] = restart_machine_state(3);
            return states;
        }

        public Dictionary<long, ESDL.State> create_boss_back_fog_gate_event_2nd_impl(long id,
            int warp_obj_inst_id, int event_loc, int map_id, int boss_destruction_id
        )
        {
            Dictionary<long, ESDL.State> states = new();
            states[0] = create_state_init(id, 2);
            states[1] = create_boss_back_state_one(id, warp_obj_inst_id, event_loc, map_id);
            states[2] = create_boss_back_state_two_2nd_impl(id, warp_obj_inst_id, event_loc, map_id, boss_destruction_id);
            states[3] = restart_machine_state(3);
            return states;
        }

        ESDL.State create_state_init(long id, long target_state = 2)
        {
            ESDL.Condition condition = new();
            condition.TargetState = target_state;
            ESDL.State state = new();
            state.Conditions.Add(condition);
            state.Name = $"State{id}-0";
            state.ID = 0;
            return state;
        }

        ESDL.State create_state_is_player_inside_point(long id, long state_id,
            long target_state, int trigger_area_id)
        {
            ESDL.State state = new();
            ESDL.Condition condition = new();
            condition.Evaluator = "ConditionGroup(0)";
            condition.TargetState = target_state;
            state.Conditions.Add(condition);
            state.Name = $"State{id}-0";
            state.ID = state_id;
            state.EntryScript = $"IsPlayerInsidePoint(0, {trigger_area_id}, {trigger_area_id}, 1);";
            return state;
        }

        ESDL.State create_is_player_in_game_state(long id, long state_id, long target_state)
        {
            ESDL.State state = new();
            ESDL.Condition condition = new();
            condition.Evaluator = "InGame() != 0";
            condition.TargetState = target_state;
            state.Conditions.Add(condition);
            state.Name = $"State{id}-0";
            state.ID = state_id;
            return state;
        }

        ESDL.State create_change_obj_state(long id, long state_id, long target_state, int obj_inst_id)
        {
            ESDL.State state = new();
            ESDL.Condition condition = new();
            condition.Evaluator = $"CompareObjStateId({obj_inst_id}, 100, 1)";
            condition.TargetState = target_state;
            state.Conditions.Add(condition);
            state.EntryScript = $"ChangeObjState({obj_inst_id}, 100);";
            state.Name = $"State{id}-0";
            state.ID = state_id;
            return state;
        }


        public Dictionary<long, ESDL.State> create_boss_cutscene_event(long id,
            int trigger_area_id, int fog_obj_inst_id
        )
        {
            Dictionary<long, ESDL.State> states = new();
            long state_id = 0;
            states[state_id] = create_state_init(id, 2); state_id++;
            states[state_id] = create_state_is_player_inside_point(id, state_id++, 3, trigger_area_id);
            states[state_id] = create_is_player_in_game_state(id, state_id++, 1);
            states[state_id] = create_change_obj_state(id, state_id++, 4, fog_obj_inst_id);
            states[state_id] = restart_machine_state(state_id);
            return states;
        }

        ESDL.State create_disable_keyguide_and_wait_for_interact_event(long id, long state_id,
            int warp_obj_inst_id, int event_loc, int map_id
        )
        {
            ESDL.Condition condition = B9neBA(3);
            ESDL.State state = new();
            state.EntryScript = $"DisableObjKeyGuide({warp_obj_inst_id}, 0);\n6:2147483145({warp_obj_inst_id});";
            state.Conditions.Add(condition);
            state.Name = $"State{id}-{state_id}";
            state.ID = state_id;
            return state;
        }

        ESDL.Condition create_target_condition(long target)
        {
            return new ESDL.Condition()
            {
                TargetState = target,
                Evaluator = "1"
            };
        }


        ESDL.State create_check_all_enemies_dead(long id,
            int warp_obj_inst_id, int event_loc, int map_id, List<int> enemy_ids
        )
        {
            ESDL.State state = new();
            ESDL.Condition c1 = assert_condition_group(8, 1);
            state.Conditions.Add(c1);
            ESDL.Condition c2 = create_target_condition(4);
            state.Conditions.Add(c2);
            state.EntryScript = $"DisableObjKeyGuide({warp_obj_inst_id}, 1);";
            foreach (var i in enemy_ids)
            {
                state.EntryScript += $"\nIsChrDeadOrRespawnOver(8, {i}, 1);";
            }
            state.Name = $"State{id}-2";
            state.ID = 2;
            return state;
        }

        ESDL.State create_set_chasm_complete_warp(long id, long state_id, int event_flag, int warp_obj_inst_id, int event_loc, int map_id)
        {
            ESDL.State state = new();
            ESDL.Condition c1 = B9neBA(4);
            state.Conditions.Add(c1);
            state.EntryScript = $"SetEventFlag({event_flag}, 1);\n6:2147483144({event_loc}, {warp_obj_inst_id}, {map_id});";
            state.Name = $"State{id}-{state_id}";
            state.ID = state_id;
            return state;
        }

        public void create_chasm_exit_gate_event(ESDL esd, long id,
            int warp_obj_inst_id, int event_loc, int map_id, List<int> enemy_ids, int event_flag
        )
        {
            Dictionary<long, ESDL.State> states = new();
            states[0] = create_state_init(id, 2);
            states[1] = create_disable_keyguide_and_wait_for_interact_event(id, 1, warp_obj_inst_id, event_loc, map_id);
            states[2] = create_check_all_enemies_dead(id, warp_obj_inst_id, event_loc, map_id, enemy_ids);
            states[3] = create_set_chasm_complete_warp(id, 3, event_flag, warp_obj_inst_id, event_loc, map_id);
            states[4] = restart_machine_state(4);
            esd.StateGroupNames[id] = $"StateGroup{id}";
            esd.StateGroups[id] = states;
        }

    }

    public class ESDEditor
	{
		EzSembleContext ctx;
		Dictionary<String, ESDL> esds = new();
		PreDefinedStates fns = new();
		public ESDEditor() 
		{
			String src_path = "./res";
			String name = "ESDScriptingDocumentation_Event";
			ctx = EzSembleContext.LoadFromXml(Path.Join(src_path, $"{name}.xml"));
			var doc_option = new ESDDocumentation.DocOptions();
			doc_option.Game = "ds2s";
			ctx.Doc = ESDDocumentation.DeserializeFromFile(Path.Join(src_path, $"{name}.json"), doc_option);
		}

		public bool is_map_loaded(String map_name)
		{
			return esds.ContainsKey(map_name);
		}

		public void load_map(String map_name, String path)
		{
			esds[map_name] = ESDL.ReadWithContext(path, ctx);
			var state2147483146 = fns.create_state2147483146(2147483146);
			var state2147483145 = fns.create_state2147483145(2147483145);
			var state2147483144 = fns.create_state2147483144(2147483144);
            var state2147483143 = fns.create_state2147483143(2147483143);
            var state2147483142 = fns.create_state2147483142(2147483142);
            var state2147483141 = fns.create_state2147483141(2147483141, 102002, 1214);
            esds[map_name].StateGroupNames[2147483141] = "StateGroup2147483141";
			esds[map_name].StateGroups[2147483141] = state2147483141;
            esds[map_name].StateGroupNames[2147483142] = "StateGroup2147483142";
			esds[map_name].StateGroups[2147483142] = state2147483142;
            esds[map_name].StateGroupNames[2147483143] = "StateGroup2147483143";
			esds[map_name].StateGroups[2147483143] = state2147483143;
            esds[map_name].StateGroupNames[2147483144] = "StateGroup2147483144";
			esds[map_name].StateGroups[2147483144] = state2147483144;
			esds[map_name].StateGroupNames[2147483145] = "StateGroup2147483145";
			esds[map_name].StateGroups[2147483145] = state2147483145;
			esds[map_name].StateGroupNames[2147483146] = "StateGroup2147483146";
			esds[map_name].StateGroups[2147483146] = state2147483146;
        }

        public void add_normal_fog_gate_event(String map_name, long id,
			int warp_obj_inst_id, int event_loc, int map_id
		)
		{
			var state = fns.create_state(id, warp_obj_inst_id, event_loc, map_id);
			esds[map_name].StateGroupNames[id] = $"StateGroup{id}";
			esds[map_name].StateGroups[id] = state;
		}

        // added to wharf
        public void add_ship_check_fog_gate_event(String map_name, long id, int ship_arrival_flag, int global_flag)
        {
            var state = fns.create_ship_check_state(id, ship_arrival_flag, global_flag);
			esds[map_name].StateGroupNames[id] = $"StateGroup{id}";
            esds[map_name].StateGroups[id] = state;
        }
        public void add_dlc3_unfreeze_event_script(String map_name, int ivory_king_dead_flag)
        {
            Event.add_dlc3_unfreeze_event_script(esds[map_name], ivory_king_dead_flag);
        }

        // added to the place that warps to wharf
        public void add_ship_check_from_fog_gate_event(String map_name, long id,
            int warp_obj_inst_id, int event_loc, int map_id
        )
        {
            var state = fns.create_ship_check_from_state(id, warp_obj_inst_id, event_loc, map_id);
            esds[map_name].StateGroupNames[id] = $"StateGroup{id}";
            esds[map_name].StateGroups[id] = state;
        }

        // checks if boss is dead or not and prevent warp
        public void add_boss_alive_fog_gate_event(String map_name, long id,
            int warp_obj_inst_id, int event_loc, int map_id, int boss_destruction_id
        )
        {
            var state = fns.create_boss_back_fog_gate_event(id, warp_obj_inst_id, event_loc, map_id, boss_destruction_id);
            esds[map_name].StateGroupNames[id] = $"StateGroup{id}";
            esds[map_name].StateGroups[id] = state;
        }

        // checks if boss is dead or not and prevent warp (for skelelords)
        public void add_boss_alive_fog_gate_event_2nd_impl(String map_name, long id,
            int warp_obj_inst_id, int event_loc, int map_id, int boss_destruction_id
        )
        {
            var state = fns.create_boss_back_fog_gate_event_2nd_impl(id, warp_obj_inst_id, event_loc, map_id, boss_destruction_id);
            esds[map_name].StateGroupNames[id] = $"StateGroup{id}";
            esds[map_name].StateGroups[id] = state;
        }

        // play cutscene where needed for boss spawn
        public void add_play_cutscene_event(String map_name, long id,
            int trigger_area_id, int fog_obj_inst_id
        )
        {
            var state = fns.create_boss_cutscene_event(id, trigger_area_id, fog_obj_inst_id);
            esds[map_name].StateGroupNames[id] = $"StateGroup{id}";
            esds[map_name].StateGroups[id] = state;
        }

        public void save_map(String map_name, String path)
		{
			if (map_name == "m20_26_00_00" || map_name == "m50_38_00_00") return;
			if (!esds.ContainsKey(map_name)) throw new Exception($"ERROR: {map_name} has not been loaded");
			var file = File.Create(path);
			BinaryWriterEx writer = new(false, file);
			esds[map_name].WriteWithContext(writer, ctx);
		}

        public void add_aio_fog_wall_event(Warp warp)
        {
            Event.add_aio_fog_wall_event(esds, warp);
        }
	}
}
