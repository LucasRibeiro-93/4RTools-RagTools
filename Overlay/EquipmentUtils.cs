using System;
using _4RTools.Model;

namespace _4RTools.Overlay
{
	public class EquipmentUtils
	{
		public EquipmentFlags GetFlags(Client client)
		{
			var flag = EquipmentFlags.None;

			if (client.ReadMemory(EquipmentMemoryAddress.RIGHT_HAND) != 0) flag |= EquipmentFlags.RightHand;
			if (client.ReadMemory(EquipmentMemoryAddress.GARMENT) != 0) flag |= EquipmentFlags.Garment;
			if (client.ReadMemory(EquipmentMemoryAddress.LEFT_ACCESSORY) != 0) flag |= EquipmentFlags.LeftAccessory;
			if (client.ReadMemory(EquipmentMemoryAddress.ARMOR) != 0) flag |= EquipmentFlags.Armor;
			if (client.ReadMemory(EquipmentMemoryAddress.LEFT_HAND) != 0) flag |= EquipmentFlags.LeftHand;
			if (client.ReadMemory(EquipmentMemoryAddress.RIGHT_ACCESSORY) != 0) flag |= EquipmentFlags.RightAccessory;
			if (client.ReadMemory(EquipmentMemoryAddress.TOP_HEADGEAR) != 0) flag |= EquipmentFlags.TopHeadgear;
			
			return flag;
		}
	}

	[Flags]
	public enum EquipmentFlags
	{
		None = 0,
		LowerHeadgear = 1,
		RightHand = 2,
		Garment = 4,
		LeftAccessory = 8,
		Armor = 16,
		LeftHand  = 32,
		Shoes = 64,
		RightAccessory = 128,
		TopHeadgear = 256,
		MidHeadgear = 512,
	}
	
	public static class EquipmentMemoryAddress
	{
		public static int TOP_HEADGEAR = 15250284;
		public static int ARMOR = 15249388;
		public static int GARMENT = 15248940;
		public static int RIGHT_HAND = 15248716;
		public static int LEFT_HAND = 15249612;
		public static int RIGHT_ACCESSORY = 15249164;
		public static int LEFT_ACCESSORY = 15250060;
	}
}