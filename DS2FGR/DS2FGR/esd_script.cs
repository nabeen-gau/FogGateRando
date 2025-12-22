using ESDLang.Adapter;

namespace FogWallNS
{
	public class ESDState
	{
		public long script_id;
		public Dictionary<long, ESDL.State> state;

		public void create_state_init(long target_state)
		{
			ESDL.Condition condition = new();
			condition.TargetState = target_state;
			ESDL.State state = new();
			state.Conditions.Add(condition);
			state.ID = 0;
			this.state[state.ID] = state;
		}

		public void wait_until_interact_with_obj(long state_id, long target_state, int obj_inst_id)
		{
			ESDL.Condition condition = new();
			condition.Evaluator = "ConditionGroup(0)";
			condition.TargetState = target_state;
			ESDL.State state = new();
			state.Conditions.Add(condition);
			state.EntryScript = $"IsObjSearched(0, {obj_inst_id});";
			state.ID = state_id;
			this.state[state.ID] = state;
		}

		public void wait_until_event_flag(long state_id, long target_state, int flag_id)
		{
			ESDL.Condition condition = new();
			condition.Evaluator = "ConditionGroup(0)";
			condition.TargetState = target_state;
			ESDL.State state = new();
			state.Conditions.Add(condition);
			state.EntryScript = $"CompareEventFlag(0, {flag_id}, 1);";
			state.ID = state_id;
			this.state[state.ID] = state;
		}

		public void wait_until_boss_is_dead(long state_id, long target_state, int boss_destruction_flag)
		{
			wait_until_event_flag(state_id, target_state, boss_destruction_flag);
		}

		public void wait_until_boss_is_aggro(long state_id, long target_state_if_true, long target_state_if_false, int boss_hostility_flag)
		{
			ESDL.Condition c1 = new();
			c1.Evaluator = "ConditionGroup(0)";
			c1.TargetState = target_state_if_true;
			ESDL.Condition c2 = new();
			c2.TargetState = target_state_if_false;
			ESDL.State state = new();
			state.Conditions.Add(c1);
			state.Conditions.Add(c2);
			state.EntryScript = $"CompareEventFlag(0, {boss_hostility_flag}, 1);";
			state.ID = state_id;
			this.state[state.ID] = state;
		}
		public void check_if_flag_is_set(long state_id, long target_state_if_true, long target_state_if_false, int event_flag)
		{
			ESDL.Condition c1 = new();
			c1.Evaluator = $"GetEventFlag({event_flag} != 0)";
			c1.TargetState = target_state_if_true;
			ESDL.Condition c2 = new();
			c2.TargetState = target_state_if_false;
			ESDL.State state = new();
			state.Conditions.Add(c1);
			state.Conditions.Add(c2);
			state.ID = state_id;
			this.state[state.ID] = state;
		}


		public void wait_until_all_enemies_dead(long state_id, long target_state, List<int> enemy_ids)
		{
            ESDL.State state = new();
			ESDL.Condition condition = new();
			condition.Evaluator = "ConditionGroup(8)";
			condition.TargetState = target_state;
			state.Conditions.Add(condition);
			for (int i=0; i<enemy_ids.Count; i++)
            {
				if (i != 0) state.EntryScript += "\n";
				state.EntryScript += $"IsChrDeadOrRespawnOver(8, {enemy_ids[i]}, 1);";
            }
			state.ID = state_id;
			this.state[state.ID] = state;
        }


        public void disable_obj_key_guide(long state_id, long target_state, int obj_inst_id)
		{
			ESDL.Condition condition = new();
			condition.TargetState = target_state;
			ESDL.State state = new();
			state.Conditions.Add(condition);
			state.EntryScript = $"DisableObjKeyGuide({obj_inst_id}, 1);";
			state.ID = state_id;
			this.state[state.ID] = state;
		}

		public void enable_obj_key_guide(long state_id, long target_state, int obj_inst_id)
		{
			ESDL.Condition condition = new();
			condition.TargetState = target_state;
			ESDL.State state = new();
			state.Conditions.Add(condition);
			state.EntryScript = $"DisableObjKeyGuide({obj_inst_id}, 0);";
			state.ID = state_id;
			this.state[state.ID] = state;
		}

		public void disable_menu(long state_id, int obj_inst_id, long target_state)
		{
			ESDL.Condition condition = new();
			condition.TargetState = target_state;
			ESDL.State state = new();
			state.Conditions.Add(condition);
			state.EntryScript = $"ProhibitInGameMenu(1);";
			state.ID = state_id;
			this.state[state.ID] = state;
		}

		public void enable_menu(long state_id, int obj_inst_id, long target_state)
		{
			ESDL.Condition condition = new();
			condition.TargetState = target_state;
			ESDL.State state = new();
			state.Conditions.Add(condition);
			state.EntryScript = $"ProhibitInGameMenu(0);";
			state.ID = state_id;
			this.state[state.ID] = state;
		}

		public void disable_movement(long state_id, long target_state)
		{
			ESDL.Condition condition = new();
			condition.TargetState = target_state;
			ESDL.State state = new();
			state.Conditions.Add(condition);
			state.EntryScript = $"ProhibitPlayerOperation(1);";
			state.ID = state_id;
			this.state[state.ID] = state;
		}

		public void enable_movement(long state_id, int obj_inst_id, long target_state)
		{
			ESDL.Condition condition = new();
			condition.TargetState = target_state;
			ESDL.State state = new();
			state.Conditions.Add(condition);
			state.EntryScript = $"ProhibitPlayerOperation(0);";
			state.ID = state_id;
			this.state[state.ID] = state;
		}

		public void disable_invincibility(long state_id, int obj_inst_id, long target_state)
		{
			ESDL.Condition condition = new();
			condition.TargetState = target_state;
			ESDL.State state = new();
			state.Conditions.Add(condition);
			state.EntryScript = $"SetPlayerInvincible(1);";
			state.ID = state_id;
			this.state[state.ID] = state;
		}

		public void enable_invincibility(long state_id, long target_state)
		{
			ESDL.Condition condition = new();
			condition.TargetState = target_state;
			ESDL.State state = new();
			state.Conditions.Add(condition);
			state.EntryScript = $"SetPlayerInvincible(0);";
			state.ID = state_id;
			this.state[state.ID] = state;
		}

		public void warp_and_wait_until_warp_is_done(long state_id, long target_state, int map_id, int warp_dst_id)
		{
			ESDL.Condition condition = new();
			condition.Evaluator = "CutsceneWarpEnded() != 0";
			condition.PassScript = "";
			condition.TargetState = target_state;
			ESDL.State state = new();
			state.Conditions.Add(condition);
			state.EntryScript = $"PlayCutsceneAndWarpToMap(0, 0, {map_id}, {warp_dst_id}, 0);";
			state.ID = state_id;
			this.state[state.ID] = state;
		}

		public void restart_machine_state(long state_id)
		{
			ESDL.State state = new();
			state.EntryScript = "RestartMachine();";
			state.ID = state_id;
			this.state[state.ID] = state;
		}

		public void check_if_wharf_bell_has_been_rang(long state_id, 
			long target_state_if_true, long target_state_if_false, int global_event_flag)
		{
			ESDL.Condition true_cond = new();
			true_cond.Evaluator = "ConditionGroup(0)";
			true_cond.PassScript = "";
			true_cond.TargetState = target_state_if_true;
			ESDL.Condition false_cond = new() {TargetState = target_state_if_false };
			ESDL.State state = new();
			state.Conditions.Add(true_cond);
			state.Conditions.Add(false_cond);
			state.EntryScript = $"CompareEventFlag(0, {global_event_flag}, 1);";
			state.ID = state_id;
			this.state[state.ID] = state;
		}

		public void display_ring_bell_msg(long state_id, long target_state, int msg_id)
		{ 
			ESDL.Condition condition = new();
			condition.TargetState = target_state;
			ESDL.State state = new();
			state.Conditions.Add(condition);
			state.EntryScript = $"DisplayEventMessage({msg_id}, 0, 0, 0)";
			state.ID = state_id;
			this.state[state.ID] = state;
		}

		public void wait_until_msg_is_showing(long state_id)
		{ 
			ESDL.Condition condition = new();
			condition.Evaluator = "EventMessageDisplay() != 1";
			ESDL.State state = new();
			state.ExitScript = "RestartMachine();";
			state.Conditions.Add(condition);
			state.ID = state_id;
			this.state[state.ID] = state;
		}

		public void set_event_flag(long state_id, long target_id, int flag_id)
		{
            ESDL.Condition condition = new();
            condition.Evaluator = "ConditionGroup(0)";
			condition.TargetState = target_id;
            ESDL.State state = new();
            state.Conditions.Add(condition);
            state.EntryScript = $"SetEventFlag({flag_id}, 1);\nCompareEventFlag(0, {flag_id}, 1);";
			state.ID = state_id;
			this.state[state.ID] = state;
		}

		public ESDState(long script_id)
		{
			this.script_id = script_id;
			state = new();
			create_state_init(1);
		}

		public void register(ESDL esd)
		{
			esd.StateGroups[script_id] = state;
		}
	}


	public static class Event
	{
		static void add_fog_wall_event(Dictionary<String, ESDL> esds, WarpInfo from, WarpInfo to)
		{
			ESDState state = new(from.script_id);
			long state_id = 1;
			bool is_chasm_door = (from.map_name == MapNames.get[MapName.DarkChasmofOld]
                                 && from.boss.name == BossName.None
                                 && Constants.chasm_enemy_ids.ContainsKey(from.fog_wall_name));
			// if it is a boss door disable interact and wait until boss is dead
			if (from.boss.name != BossName.None && from.boss_locked)
			{
				// if the boss is vendrick only disable the key guide if he is aggro
				if (from.boss.name == BossName.Vendrick)
				{
					int n_states_to_skip = 3;
					state.wait_until_boss_is_aggro(state_id++,
						target_state_if_true: state_id,
						target_state_if_false: state_id + n_states_to_skip,
						Constants.vendricks_hostility_flag);
				}
				state.disable_obj_key_guide(state_id++, state_id, from.warp_src_id);
				state.wait_until_boss_is_dead(state_id++, state_id, from.boss.destruction_flag);
				// for final boss fight you can leave the fight if giant lord is not dead else you are locked in the fight
				if (from.boss.name == BossName.ThroneWatcherAndDefender)
				{
					int n_states_to_skip = 1;
					state.check_if_flag_is_set(state_id++,
						target_state_if_true: state_id + n_states_to_skip,
						target_state_if_false: state_id,
						Constants.giant_lord_defeat_flag);
					state.restart_machine_state(state_id++);
				}
				state.enable_obj_key_guide(state_id++, state_id, from.warp_src_id);
			}
			// if it is a chasm door disable interact and wait until the dungeon is cleared
            else if (is_chasm_door)
			{
				state.disable_obj_key_guide(state_id++, state_id, from.warp_src_id);
				state.wait_until_all_enemies_dead(state_id++, state_id, Constants.chasm_enemy_ids[from.fog_wall_name]);
				state.enable_obj_key_guide(state_id++, state_id, from.warp_src_id);
			}
			// wait until interact is pressed
            state.wait_until_interact_with_obj(state_id++, state_id, from.warp_src_id);
            // if the boss is vendrick only disable the key guide if he is aggro and enable back after he is dead
			if (from.boss.name == BossName.Vendrick)
			{
				long n_states_to_skip = 4;
				state.wait_until_boss_is_aggro(state_id++,
                    target_state_if_true:  state_id, 
                    target_state_if_false: state_id + n_states_to_skip, 
                    Constants.vendricks_hostility_flag);
				state.disable_obj_key_guide(state_id++, state_id, from.warp_src_id);
				state.wait_until_boss_is_dead(state_id++, state_id, from.boss.destruction_flag);
				state.enable_obj_key_guide(state_id++, state_id, from.warp_src_id);
                state.wait_until_interact_with_obj(state_id++, state_id, from.warp_src_id);
			}
			//// if it is from chasm set the dungeon complete flag
			if (is_chasm_door)
			{
				state.set_event_flag(state_id++, state_id, Constants.chasm_event_flags[from.fog_wall_name]);
			}
			// if it warps to wharf check if ship has arrived and wait until it has
			if (Util.is_bell_check_required(to.map_name, to.fog_wall_name))
			{
				int n_states_to_skip = 3;
				state.check_if_wharf_bell_has_been_rang(state_id++, state_id + n_states_to_skip, state_id, Constants.ship_global_event_flag);
				state.disable_obj_key_guide(state_id++, state_id, from.warp_src_id);
				state.display_ring_bell_msg(state_id++, state_id, Constants.ship_arrival_msg_id);
				state.wait_until_msg_is_showing(state_id++);
			}
			// start warping
			state.disable_obj_key_guide(state_id++, state_id, from.warp_src_id);
			state.disable_movement(state_id++, state_id);
			state.warp_and_wait_until_warp_is_done(state_id++, state_id,
				Util.parse_map_name(to.map_name), to.location_id);
			state.restart_machine_state(state_id++);
			state.register(esds[from.map_name]);
		}

		public static void add_aio_fog_wall_event(Dictionary<String, ESDL> esds, Warp warp)
		{
			add_fog_wall_event(esds, warp.from, warp.to);
			add_fog_wall_event(esds, warp.to, warp.from);
		}

        public static void add_dlc3_unfreeze_event_script(ESDL esd, int ivory_king_dead_flag)
		{
			ESDState state = new(Constants.dlc_unfreeze_event_id);
			long state_id = 1;
            int n_states_to_skip = 1;
			state.wait_until_event_flag(state_id++, state_id, ivory_king_dead_flag);
			state.check_if_flag_is_set(state_id++, state_id + n_states_to_skip, state_id, Constants.alsanna_talk_flag);
			state.set_event_flag(state_id++, state_id, Constants.alsanna_talk_flag);
			state.restart_machine_state(state_id++);
			state.register(esd);
		}
	}
}