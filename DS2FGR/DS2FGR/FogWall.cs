namespace FogWallNS
{
	public struct FogWall
	{
		public String name;
		public String map_name;
		public int instance_id;
		bool boss;
		bool pvp;
		bool boss_exit;
		public FogWall(String name, String map_name, int instance_id, bool boss = false, bool pvp = false, bool boss_exit = false)
		{
			this.name = name;
			this.map_name = map_name;
			this.instance_id = instance_id;
			this.boss = boss;
			this.pvp = pvp;
			this.boss_exit = boss_exit;
		}
	};

	enum MapName
	{
		ThingsBetwixt = 0,
		ForestOfTheFallenGiants,
		BrightstoneCoveTseldora,
	}

}