using ESDLang.Adapter;
using ESDLang.Doc;
using ESDLang.EzSemble;
using SoulsFormats;

namespace FogWallNS
{
	public class PreDefinedStates
	{
		public ESDL.State create_state_zero(long id)
		{
			ESDL.Condition condition = new();
			condition.Evaluator = "1";
			condition.PassScript = "";
			condition.TargetState = 2;
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
			states[0] = create_state_zero(id);
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

		public void save_map(String map_name, String path)
		{
			if (map_name == "m20_26_00_00" || map_name == "m50_38_00_00") return;
			if (!esds.ContainsKey(map_name)) throw new Exception($"ERROR: {map_name} has not been loaded");
			var file = File.Create(path);
			BinaryWriterEx writer = new(false, file);
			esds[map_name].WriteWithContext(writer, ctx);
		}
	}
}
