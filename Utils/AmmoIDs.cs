using System;
using _4RTools.Model;

namespace _4RTools.Utils
{
	public static class AmmoUtils
	{
		public static int GetMemoryAddress()
		{
			var client = ClientSingleton.GetClient();
			if (client == null) return -1;

			return client.currentHPBaseAddress - 18144;
		}
	}
	
	[Flags]
	public enum AmmoIDs : uint
	{
		// ARROWS
		ARROW = 7,
		ORIDECON_ARROW = 65,
		IRON_ARROW = 36,
		STEEL_ARROW = 55,

		EARTH_ARROW = 22,
		WIND_ARROW = 25,
		FIRE_ARROW = 28,
		CRYSTAL_ARROW = 31,
		IMMATERIAL_ARROW = 18,
		SHADOW_ARROW = 30,
		SILVER_ARROW = 33,
		HOLY_ARROW = 58,

		SLEEP_ARROW = 56,
		POISON_ARROW = 57,
		BLIND_ARROW = 59,
		RUSTY_ARROW = 60,
		MUTE_ARROW = 61,
		FREEZING_ARROW = 62,
		STUN_ARROW = 63,
		SHARP_ARROW = 64,

		// BULLETS
		BULLET = 45,
		BLOODY_BULLET = 40,
		SILVER_BULLET = 34,

		FIRE_BULLET = 41,
		ICE_BULLET = 42,
		WIND_BULLET = 43,
		EARTH_BULLET = 44,

		FIRE_GRENADE = 46,
		WIND_GRENADE = 47,
		POISON_GRENADE = 48,
		BLIND_GRENADE = 49,
		WATER_GRENADE = 50,
	}
}