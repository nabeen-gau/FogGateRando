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
            using (var file = File.Create(path))
            {
                var writer = new BinaryWriterEx(false, file);
                esds[map_name].WriteWithContext(writer, ctx);
            }
		}

        public void add_aio_fog_wall_event(Warp warp, int ship_arrival_msg_id)
        {
            Event.add_aio_fog_wall_event(esds, warp, ship_arrival_msg_id);
        }
	}
}
