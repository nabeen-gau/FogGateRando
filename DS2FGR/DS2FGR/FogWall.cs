using System.Numerics;

namespace FogWallNS
{
	public class FogWall
	{
		public String name;
		public String map_name;
		public int instance_id;
		public int boss;
		bool pvp;
		public bool cutscene;
		public bool boss_exit;
		public Vector3? offset;
		public int event_id; // cutscene event id
		public BossName enum_id;
		public int destruction_flag;
        public FogWall(String name, String map_name, BossName boss_enum_id = BossName.None,
			int boss = -1, int event_id = -1,
			bool pvp = false, bool boss_exit = false, bool cutscene = false)
		{
			this.name = name;
			this.map_name = map_name;
			this.instance_id = -1;
			this.boss = boss;
			this.pvp = pvp;
			this.boss_exit = boss_exit;
			this.offset = null;
			this.cutscene = cutscene;
			this.event_id = event_id;
			this.enum_id = boss_enum_id;
			this.destruction_flag = -1;
		}
	};

	enum MapName
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
		LastGiant,
		RoyalRatVanguard,
        Pursuer,
	}
}
