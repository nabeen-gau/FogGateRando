using System.Numerics;

namespace FogWallNS
{
	public class FogWall
	{
		public String name;
		public String map_name;
		public int instance_id;
		bool boss;
		bool pvp;
		bool boss_exit;
		public Vector3? offset;
        public FogWall(String name, String map_name, bool boss = false, bool pvp = false, bool boss_exit = false)
		{
			this.name = name;
			this.map_name = map_name;
			this.instance_id = -1;
			this.boss = boss;
			this.pvp = pvp;
			this.boss_exit = boss_exit;
			this.offset = null;
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

}