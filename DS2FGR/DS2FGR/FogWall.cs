using System.Diagnostics;
using System.Numerics;

namespace FogWallNS
{
	public static class MapNames
	{
        public static readonly Dictionary<MapName, String> get = new Dictionary<MapName, String>()
        {
            { MapName.ThingsBetwixt,                "m10_02_00_00"},
            { MapName.Majula,                       "m10_04_00_00"},
            { MapName.ForestOfTheFallenGiants,      "m10_10_00_00"},
            { MapName.BrightstoneCoveTseldora,      "m10_14_00_00"},
            { MapName.AldiasKeep,                   "m10_15_00_00"},
            { MapName.TheLostBastilleBelfryLuna,    "m10_16_00_00"},
            { MapName.HarvestValleyEarthenPeak,     "m10_17_00_00"},
            { MapName.NomansWharf,                  "m10_18_00_00"},
            { MapName.IronKeepBelfrySol,            "m10_19_00_00"},
            { MapName.HuntsmanCopseUndeadPurgatory, "m10_23_00_00"},
            { MapName.TheGutterBlackGulch,          "m10_25_00_00"},
            { MapName.DragonAerieDragonShrine,      "m10_27_00_00"},
            { MapName.MajulaShadedWoods,            "m10_29_00_00"},
            ////{ MapName.HeidesToNoMansWharf,          "m10_30_00_00"}, // disabled (no fog gates)
            { MapName.HeidesTowerofFlame,           "m10_31_00_00"},
            { MapName.ShadedWoodsShrineofWinter,    "m10_32_00_00"},
            { MapName.DoorsofPharros,               "m10_33_00_00"},
            { MapName.GraveofSaints,                "m10_34_00_00"},
            { MapName.MemoryofVammarOrroandJeigh,   "m20_10_00_00"},
            { MapName.ShrineofAmana,                "m20_11_00_00"},
            { MapName.DrangleicCastleThroneofWant,  "m20_21_00_00"},
            { MapName.UndeadCrypt,                  "m20_24_00_00"},
            { MapName.DragonMemories,               "m20_26_00_00"}, // disabled (no fog gates)
            { MapName.DarkChasmofOld,               "m40_03_00_00"},
            { MapName.ShulvaSanctumCity,            "m50_35_00_00"},
            { MapName.BrumeTower,                   "m50_36_00_00"},
            { MapName.FrozenEleumLoyce,             "m50_37_00_00"},
            { MapName.MemoryoftheKing,              "m50_38_00_00"}, // disabled (no fog gates)
        };
    }
    public class FogWall
	{
		public WarpNode name;
		public String map_name;
		public int instance_id;
		bool pvp;
		public bool cutscene;
		public bool boss_exit;
		public Vector3? offset;
		public int event_id; // cutscene event id
		public BossName boss_name;
		public int destruction_flag;
		public int twin_gate_id;
		public bool use_second_death_check_impl;
		public bool reverse;
		public bool front_blocked;
		public bool back_blocked;
		public FogWall(WarpNode name, String map_name, BossName boss_name = BossName.None,
			int event_id = -1, bool use_second_death_check_impl = false, bool reverse = false,
			bool pvp = false, bool boss_exit = false, bool cutscene = false, bool front_blocked = false, bool back_blocked = false)
		{
			this.name = name;
			this.map_name = map_name;
			this.instance_id = -1;
			this.pvp = pvp;
			this.boss_exit = boss_exit;
			this.offset = null;
			this.cutscene = cutscene;
			this.event_id = event_id;
			this.boss_name = boss_name;
			this.destruction_flag = -1;
			this.twin_gate_id = -1;
			this.use_second_death_check_impl = use_second_death_check_impl;
			this.reverse = reverse;
			this.front_blocked = front_blocked;
            this.back_blocked = back_blocked;
		}

        public FogWall get_back_gate()
        {
			var copy = (FogWall)this.MemberwiseClone();
            string name = copy.name.ToString();
            if (name.EndsWith("Front"))
            {
                name = name.Replace("Front", "Back");
            }
            else if (name.EndsWith("Back"))
            {
                name = name.Replace("Back", "Front");
            }
			else
			{
				throw new Exception($"Could not parse the name `{copy.name}`");
			}
            copy.name = (WarpNode)Enum.Parse(typeof(WarpNode), name);
			return copy;
        }


    };

	public enum MapName
	{
		ThingsBetwixt = 0,
		Majula,
		ForestOfTheFallenGiants,
		BrightstoneCoveTseldora,
		AldiasKeep,
		TheLostBastilleBelfryLuna,
		HarvestValleyEarthenPeak,
		NomansWharf,
		IronKeepBelfrySol,
		HuntsmanCopseUndeadPurgatory,
		TheGutterBlackGulch,
		DragonAerieDragonShrine,
		MajulaShadedWoods,
		HeidesToNoMansWharf,
		HeidesTowerofFlame,
        ShadedWoodsShrineofWinter,
		DoorsofPharros,
		GraveofSaints,
		MemoryofVammarOrroandJeigh,
		ShrineofAmana,
		DrangleicCastleThroneofWant,
		UndeadCrypt,
		DragonMemories,
		DarkChasmofOld,
		ShulvaSanctumCity,
		BrumeTower,
		FrozenEleumLoyce,
		MemoryoftheKing
	}

	public enum BossName
	{
		None,
		TheLastGiant,
        ThePursuer,
		Dragonrider,
		OldDragonslayer,
		FlexileSentry,
		RuinSentinels,
		TheLostSinner,
		BelfryGargoyles,
		SkeletonLords,
		ExecutionersChariot,
		CovetousDemon,
		MythaTheBanefulQueen,
		SmelterDemon,
		OldIronKing,
		ScorpionessNajka,
		RoyalRatAuthority,
		ProwlingMagusAndCongregation,
		TheDukesDearFreja,
		RoyalRatVanguard,
		TheRotten,
		TwinDragonrider,
		LookingGlassKnight,
		DemonofSong,
		VelstadtTheRoyalAegis,
		Vendrick,
		GuardianDragon,
		AncientDragon,
		GiantLord,
		ThroneWatcherAndDefender,
		Nashandra,
		AldiaScholarOfTheFirstSin,
		Darklurker,
		ElanaTheSqualidQueen,
		SinhTheSlumberingDragon,
		Gankfight,
		FumeKnight,
		SirAlonne,
		BlueSmelterDemon,
		AavaTheKingsPet,
		BurntIvoryKing,
		LudAndZallen
	}


	public struct StringChange
	{
		public String from;
		public String to;

		public StringChange(String from, String to)
		{
			this.from = from;
			this.to = to;
		}
	}

	public struct EventID
	{
		public int event_loc_id;
		public Vector3 position;

		public EventID(int event_loc_id, Vector3 position)
		{
			this.event_loc_id = event_loc_id;
			this.position = position;
		}
	}

	public static class Util
	{
		public static bool is_bell_check_required(String map_name, WarpNode node)
		{
			if (map_name == MapNames.get[MapName.NomansWharf]
				&& (node != WarpNode.NoMansWharfToHeidesBack && node != WarpNode.NoMansWharfToHeidesFront)) 
                    return true;
			return false;
        }

        public static String check_backup(String name)
        {
            if (!File.Exists(name + ".bak"))
            {
                File.Copy(name, name + ".bak");
                Console.WriteLine($"[BACKUP] {name}.bak created.");
            }
            return name + ".bak";
        }

        public static String read_string_from_file(String file_path)
        {
            try
            {
                String str = File.ReadAllText(file_path);
                Console.WriteLine($"[SUCCESS] {file_path} loaded.");
                return str;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"[ERROR] {file_path} not found: {ex.Message}");
                return "";
            }
            catch (IOException ex)
            {
                Console.WriteLine($"[ERROR] {file_path} read error: {ex.Message}");
                return "";
            }
        }

        public static int parse_map_name(string mapCode)
        {
            // Remove non-numeric characters and concatenate the numbers
            string numericPart = string.Empty;
            foreach (char c in mapCode)
            {
                if (char.IsDigit(c))
                {
                    numericPart += c;
                }
            }
            // Parse the resulting string to an integer
            return int.Parse(numericPart);
        }

	}

	public class Constants
	{
		public const int throne_watcher_defender_defeat_flag = 221000091;
		public const int giant_lord_defeat_flag = 100972;
		public const int nashandra_cutscene_flag = 12010;
		public const int vendricks_hostility_flag = 224000088;
		public const int ship_global_event_flag = 102002;
		public const int ship_arrival_local_flag = 118000010;
		public const int ship_event_id = 1007;
		public const int dlc_unfreeze_event_id = 1075;
		public const int alsanna_talk_flag = 537000011;
		public const int ruin_sentinels_spawn_event_loc_id = 1400000;
		public const float ruin_sentinels_spawn_event_posy = -4.522f;
		public const float ruin_sentinels_spawn_event_scaley = 16.0f;
        public const String ship_arrival_msg = "Ghost ship in No Mans Wharf not docked";

        public readonly static Dictionary<WarpNode, List<int>> chasm_enemy_ids = new Dictionary<WarpNode, List<int>>()
        {
            {WarpNode.DarkChasmFromBlackGulchExitFront, new List<int>(){1005, 1006, 1007, 1008, 3200, 3210 } },
            {WarpNode.DarkChasmFromDrangleicCastleExitFront, new List<int>(){1004, 1009, 1012, 3100} },
            {WarpNode.DarkChasmFromShadedWoodsExitFront, new List<int>(){1000, 1002, 1003, 3000} },
        };
        public readonly static Dictionary<WarpNode, int> chasm_event_flags = new()
        {
            {WarpNode.DarkChasmFromShadedWoodsExitFront, 403000001},
            {WarpNode.DarkChasmFromDrangleicCastleExitFront, 403000002},
            {WarpNode.DarkChasmFromBlackGulchExitFront, 403000003},
        };

        public readonly static Dictionary<BossName, int> boss_destruction_flags = new Dictionary<BossName, int>()
        {
            {BossName.TheLastGiant,                 110000081},
            {BossName.ThePursuer,                   110000086},
            {BossName.Dragonrider,                  131000081},
            {BossName.OldDragonslayer,              131000086},
            {BossName.FlexileSentry,                118000081},
            {BossName.RuinSentinels,                116000081},
            {BossName.TheLostSinner,                116000086},
            {BossName.BelfryGargoyles,              116000091},
            {BossName.SkeletonLords,                123000086},
            {BossName.ExecutionersChariot,          123000081},
            {BossName.CovetousDemon,                117000081},
            {BossName.MythaTheBanefulQueen,         117000091},
            {BossName.SmelterDemon,                 119000081},
            {BossName.OldIronKing,                  119000086},
            {BossName.ScorpionessNajka,             132000081},
            {BossName.RoyalRatAuthority,            133000081},
            {BossName.ProwlingMagusAndCongregation, 114000096},
            {BossName.TheDukesDearFreja,            114000081},
            {BossName.RoyalRatVanguard,             134000081},
            {BossName.TheRotten,                    125000081},
            {BossName.TwinDragonrider,              221000081},
            {BossName.LookingGlassKnight,           221000086},
            {BossName.DemonofSong,                  211000081},
            {BossName.VelstadtTheRoyalAegis,        224000081},
            {BossName.Vendrick,                     224000086},
            {BossName.GuardianDragon,               115000081},
            {BossName.AncientDragon,                127000081},
            {BossName.GiantLord,                    210000081},
            {BossName.ThroneWatcherAndDefender,     221000091},
            {BossName.Nashandra,                    221000096},
            {BossName.AldiaScholarOfTheFirstSin,    221000006},
            {BossName.Darklurker,                   403000081},
            {BossName.ElanaTheSqualidQueen,         535000081},
            {BossName.SinhTheSlumberingDragon,      535000096},
            {BossName.Gankfight,                    535000091},
            {BossName.FumeKnight,                   536000081},
            {BossName.SirAlonne,                    536000086},
            {BossName.BlueSmelterDemon,             536000091},
            {BossName.AavaTheKingsPet,              537000081},
            {BossName.BurntIvoryKing,               537000086},
            {BossName.LudAndZallen,                 537000091},
        };

        // in event param if
        // 0x8 - 0xa = 0
        // 0xa = 1
        // 0xc = 0
        // 0xd = 5
        // 0xe - 0xf = 0
        // the event is for cutscene
        // for nashandra = 12010
        // cutscene event id: EventEnded(id)
        public readonly static Dictionary<BossName, int> boss_event_ids = new Dictionary<BossName, int>()
        {
            {BossName.TheLastGiant, 6510 },
            {BossName.ThePursuer, 6010 },
            {BossName.TheLostSinner, 15010 },
            {BossName.ExecutionersChariot, 9010 },
            {BossName.OldIronKing, 15010 },
            {BossName.TheDukesDearFreja, 4010 },
            {BossName.TheRotten, 5010 },
            {BossName.VelstadtTheRoyalAegis, 4010 },
            {BossName.ThroneWatcherAndDefender, 12010 },
        };

        public readonly static Dictionary<BossName, int> boss_spawn_event_loc = new Dictionary<BossName, int>()
        {
            {BossName.TheDukesDearFreja, 100000 },
            {BossName.OldIronKing, 1500000 },
            {BossName.Darklurker, 200000 },
        };


    }

    public struct FogGateInfo
	{
		public String map_name;
		public FogGateType type;
		public FogWall fogwall;
		public String content;

		public FogGateInfo(String map_name, FogWall fogwall)
		{
			this.map_name = map_name;
			this.fogwall = fogwall;
			type = new();
			content  = "";
		}
	}

	public struct FogGateType
	{
		public FogGateDetails front;
		public FogGateDetails back;
		public FogGateType(int script_id, int warp_src_id, int warp_dst_id, int warp_dst_map_id,
			List<int>? enemy_ids = null, int chasm_event_flag = -1)
		{
			front = new(script_id,     warp_src_id,     warp_dst_id,     warp_dst_map_id, enemy_ids, chasm_event_flag);
			back  = new(script_id + 1, warp_src_id + 1, warp_dst_id + 1, warp_dst_map_id, enemy_ids, chasm_event_flag);
		}
	}

	public struct FogGateDetails
	{
		public int script_id;
		public int warp_src_id;
		public int warp_dst_id;
		public List<int>? enemy_ids;
		public int chasm_event_flag;
		public int warp_dst_map_id;

		public FogGateDetails(int script_id, int warp_src_id, int warp_dst_id, int warp_dst_map_id,
			List<int>? enemy_ids = null, int chasm_event_flag = -1)
		{
            this.script_id = script_id;
            this.warp_src_id = warp_src_id;
            this.warp_dst_id = warp_dst_id;
			this.warp_dst_map_id = warp_dst_map_id;
            this.enemy_ids = enemy_ids;
            this.chasm_event_flag = chasm_event_flag;
		}
	}

	public struct BossDetails
	{
		public WarpNode name_str;
		public BossName name;
		public int destruction_flag;
		public bool use_second_death_check_impl;
		public bool cutscene;
		public bool exit;

		public BossDetails(FogWall fw)
		{
			name_str = fw.name;
			name = fw.boss_name;
			destruction_flag = fw.destruction_flag;
			use_second_death_check_impl = fw.use_second_death_check_impl;
			cutscene = fw.cutscene;
			exit = fw.boss_exit;
		}
	}

    [DebuggerDisplay("{fog_wall_name}")]
    public struct WarpInfo
	{
		public String map_name;
		public int script_id;
		public int warp_src_id;
		public int fog_gate_id;
		public int location_id;
		public BossDetails boss;
		public List<int>? enemy_ids;
		public int chasm_event_flag;
		public bool boss_locked;
		public WarpNode fog_wall_name;
		public int cutscene_script_id;
		public int twin_fog_gate_id;
		public bool front;

		public WarpInfo(String map_name, int script_id, int warp_src_id, int fog_gate_id, int location_id, FogWall fw,
			List<int>? enemy_ids = null, int chasm_event_flag = -1, bool boss_locked = true, int cutscene_script_id = -1,
			bool front = false)
        {
            this.map_name = map_name;
            this.script_id = script_id;
			this.warp_src_id = warp_src_id;
            this.fog_gate_id = fog_gate_id;
            this.location_id = location_id;
			boss = new BossDetails(fw);
			this.enemy_ids = enemy_ids;
			this.chasm_event_flag = chasm_event_flag;
			this.boss_locked = boss_locked;
			fog_wall_name = fw.name;
			this.cutscene_script_id = cutscene_script_id;
			twin_fog_gate_id = fw.twin_gate_id;
			this.front = front;
		}
	}

    [DebuggerDisplay("{from.fog_wall_name} <-> {to.fog_wall_name}")]
	public struct Warp
	{
		public WarpInfo from;
		public WarpInfo to;
		public Cond cond = Cond.None;

		public Warp(FogGateInfo fgi)
		{
			bool boss_locked_from = false;
			bool boss_locked_to   = false;
            if (fgi.fogwall.boss_name != BossName.None)
			{
				boss_locked_from =  fgi.fogwall.boss_exit;
				boss_locked_to   = !fgi.fogwall.boss_exit;
			}
			int cutscene_script_id = -1;
			if (fgi.fogwall.cutscene)
			{
				cutscene_script_id = fgi.type.back.script_id + 1;
			}
			from = new(fgi.map_name, fgi.type.front.script_id, fgi.type.front.warp_src_id, fgi.fogwall.instance_id,
				fgi.type.back.warp_dst_id, fgi.fogwall, 
				enemy_ids: fgi.type.front.enemy_ids, chasm_event_flag: fgi.type.front.chasm_event_flag, 
				boss_locked: boss_locked_from, cutscene_script_id: cutscene_script_id, front: true);
			to   = new(fgi.map_name, fgi.type.back.script_id, fgi.type.back.warp_src_id, fgi.fogwall.instance_id,
				fgi.type.front.warp_dst_id, fgi.fogwall.get_back_gate(), 
				enemy_ids: fgi.type.front.enemy_ids, chasm_event_flag: fgi.type.front.chasm_event_flag,
				boss_locked: boss_locked_to, cutscene_script_id: cutscene_script_id, front: false);
		}

        public Warp(WarpInfo from, WarpInfo to, Cond cond = Cond.None)
        {
            this.from = from;
            this.to = to;
			this.cond = cond;
        }

		public bool contains_common_point(Warp other)
		{
			if (
				this.from.fog_wall_name == other.from.fog_wall_name
				|| this.from.fog_wall_name == other.to.fog_wall_name
				|| this.to.fog_wall_name == other.to.fog_wall_name
				|| this.to.fog_wall_name == other.from.fog_wall_name
			) return true;
			return false;
		}

        public static bool operator ==(Warp a, Warp b)
        {
            return a.from.fog_wall_name == b.from.fog_wall_name && a.to.fog_wall_name == b.to.fog_wall_name;
        }
        public static bool operator !=(Warp a, Warp b)
        {
            return a.from.fog_wall_name != b.from.fog_wall_name || a.to.fog_wall_name != b.to.fog_wall_name;
        }

        public override bool Equals(object? obj)
        {
			if (obj == null) return false;
			var other = (Warp)obj;
			return from.fog_wall_name == other.from.fog_wall_name && to.fog_wall_name == other.to.fog_wall_name;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }

    public static class WarpScrambler
    {
        private static Random rng = new Random();
        public static List<Warp> Scramble(List<Warp> warps)
        {
            int n = warps.Count;
            if (n <= 1) return new List<Warp>(warps);
			List<WarpInfo> allList = new List<WarpInfo>(2 * n);

            foreach (var w in warps)
            {
				allList.Add(w.from);
				allList.Add(w.to);
            }
            Shuffle(allList);
			List<WarpInfo> fromList = allList[..n];
			List<WarpInfo> toList = allList[n..(2*n)];
            var result = new List<Warp>(n);
            for (int i = 0; i < n; i++)
            {
                result.Add(new Warp(fromList[i], toList[i]));
            }
            return result;
        }

        private static void Shuffle<T>(IList<T> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }
    }
}
