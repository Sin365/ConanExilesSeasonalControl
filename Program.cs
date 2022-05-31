using System;
using System.Collections.Generic;
using System.Timers;
using MinecraftServerRCON;
using Timer = System.Timers.Timer;

namespace ConanExilesSeasonalControl
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.Title = "皓月云 - 柯南服务端 生态控制系统 Ver 0.1";
			Program.justdoit();
			Program.StartSeasonde();
			while (true)
			{
				Console.ReadLine();
			}
		}

		private static void StartSeasonde()
		{
			Timer aTimer = new Timer();
			aTimer.Elapsed += Program.SeasondeTimeEvent;
			aTimer.Interval = 600000.0;
			aTimer.Enabled = true;
		}

		private static void SeasondeTimeEvent(object source, ElapsedEventArgs e)
		{
			Program.justdoit();
		}

		private static void justdoit()
		{
			DateTime t0 = new DateTime(2020, 3, 18);
			DateTime dt = DateTime.Now;
			double seasondehours = 3.5;
			int seasondeIndex = 2;
			while (t0 < dt)
			{
				seasondeIndex++;
				bool flag = seasondeIndex > 2;
				if (flag)
				{
					seasondeIndex = 0;
				}
				t0 = t0.AddHours(seasondehours);
			}
			string seasondeNow = "";
			string seasondeNext = "";
			switch (seasondeIndex)
			{
				case 0:
					seasondeNow = "温暖繁殖期";
					seasondeNext = "炎热富饶期";
					break;
				case 1:
					seasondeNow = "炎热富饶期";
					seasondeNext = "寒冷保守期";
					break;
				case 2:
					seasondeNow = "寒冷保守期";
					seasondeNext = "温暖繁殖期";
					break;
			}
			bool ShowBoxFlag = true;
			bool flag2 = Program.doingindex == seasondeIndex;
			if (flag2)
			{
				Console.WriteLine(DateTime.Now.ToString() + " 当前正处于【" + seasondeNow + "】");
				ShowBoxFlag = false;
			}
			else
			{
				Console.WriteLine(DateTime.Now.ToString() + " 准备更替季节【" + seasondeNow + "】");
			}
			Program.doingindex = seasondeIndex;
			string joinmsg = string.Concat(new string[]
			{
				"con 0 setserversetting \"ServerMessageOfTheDay\" \"皓月原创 - 季 节 系 统<br>当前季节 -> 【",
				seasondeNow,
				"】<br>下一季节 -> 【",
				seasondeNext,
				"】<br>到来时间->",
				t0.ToString("HH:mm"),
				"<br>掌握季节特性，使您更得心应手，是本服原创乐趣。<br>季节说明：（也可以在群相册看图表）<br>【温暖繁殖期】 推荐进行抓动物奴隶，训练速度较快，动物数量上升，但繁殖期动物比较凶猛。<br>(昼长↑/夜长↓/耐力消耗↓/口渴↑/仆役训练速度↑↑/野狗交·配/繁殖量↑↑/宠物伤害↑↑/爪牙类伤害↑↑/仇恨追逐范围↑↑)<br><br>【炎热富饶期】 推荐采集物资，物产丰富，不过要做好充分准备，炎热的夏天体能会差一些的。<br>(昼长↑↑/夜长↓↓/资源产出↑↑/资源刷新↑/冲刺速度↓/耐力耗费↑/口渴↑↑/饥饿↑/负重能力↓↓/宠物伤害↑/爪牙类伤害↑)<br><br>【寒冷保守期】 推荐在家建设，建造获得经验上升，建造速度微升，容易饿，进入严冬之前尽量先做好储备。<br>(昼长↓↓/夜长↑↑/耐力耗费↑↑/制造速度↑/制造经验↑/资源产出↓/资源刷新↓/燃料持久↓↓/冲刺速度↓↓/饥饿↑↑/负重能力↓↓/宠物伤害↓/爪牙类伤害↓)\""
			});
			string messageboxmsg = string.Concat(new string[]
			{
				"broadcast 皓月原创 - 季 节 系 统♡当前季节 -> 【",
				seasondeNow,
				"】下一季节 -> 【",
				seasondeNext,
				"】♡到来时间->",
				t0.ToString("HH:mm"),
				"♡掌握季节特性，使您更得心应手，是本服原创乐趣。♡季节说明：（也可以在群相册看图表）♡【温暖繁殖期】 推荐进行抓动物奴隶，训练速度较快，动物数量上升，但繁殖期动物比较凶猛。♡(昼长↑/夜长↓/耐力消耗↓/口渴↑/仆役训练速度↑↑/野狗交·配/繁殖量↑↑/宠物伤害↑↑/爪牙类伤害↑↑/仇恨追逐范围↑↑)♡【炎热富饶期】 推荐采集物资，物产丰富，不过要做好充分准备，炎热的夏天体能会差一些的。♡(昼长↑↑/夜长↓↓/资源产出↑↑/资源刷新↑/冲刺速度↓/耐力耗费↑/口渴↑↑/饥饿↑/负重能力↓↓/宠物伤害↑/爪牙类伤害↑)♡【寒冷保守期】 推荐在家建设，建造获得经验上升，建造速度微升，容易饿，进入严冬之前尽量先做好储备。♡(昼长↓↓/夜长↑↑/耐力耗费↑↑/制造速度↑/制造经验↑/资源产出↓/资源刷新↓/燃料持久↓↓/冲刺速度↓↓/饥饿↑↑/负重能力↓↓/宠物伤害↓/爪牙类伤害↓)♡"
			});
			List<string> msglist = new List<string>();
			bool flag3 = ShowBoxFlag;
			if (flag3)
			{
				Console.WriteLine("需要弹窗提示");
				msglist.Add(messageboxmsg);
			}
			msglist.Add(joinmsg);
			switch (seasondeIndex)
			{
				case 0:
					Console.WriteLine(DateTime.Now.ToString() + " 【温暖繁殖期】配置");
					msglist.AddRange(Program.seasond1setting);
					break;
				case 1:
					Console.WriteLine(DateTime.Now.ToString() + " 【炎热富饶期】配置");
					msglist.AddRange(Program.seasond2setting);
					break;
				case 2:
					Console.WriteLine(DateTime.Now.ToString() + " 【寒冷保守期】配置");
					msglist.AddRange(Program.seasond3setting);
					break;
			}
			Program.RunCmd(msglist.ToArray());
			Console.WriteLine(DateTime.Now.ToString() + " 设置完毕");
		}

		private static void RunCmd(string[] cmdarr)
		{
			using (RCONClient rcon = RCONClient.INSTANCE)
			{
				rcon.setupStream(Program.rconip, Program.rconport, Program.rconpwd);
				foreach (string c in cmdarr)
				{
					rcon.sendMessage(RCONMessageType.Command, c);
					Console.WriteLine(c);
				}
			}
		}

		private static string rconip = "127.0.0.1";

		private static int rconport = 25575;

		private static string rconpwd = "123456";

		private static int doingindex = -1;

		private static string[] seasondefaultsetting = new string[]
		{
			"con 0 setserversetting \"DayTimeSpeedScale\" 1.0",
			"con 0 setserversetting \"NightTimeSpeedScale\" 1.0",
			"con 0 setserversetting \"HarvestAmountMultiplier\" 1.0",
			"con 0 setserversetting \"ResourceRespawnSpeedMultiplier\" 1.0",
			"con 0 setserversetting \"FuelBurnTimeMultiplier\" 1.0",
			"con 0 setserversetting \"PlayerSprintSpeedScale\" 1.0",
			"con 0 setserversetting \"PlayerStaminaCostMultiplier\" 1.0",
			"con 0 setserversetting \"PlayerActiveThirstMultiplier\" 1.0",
			"con 0 setserversetting \"PlayerActiveHungerMultiplier\" 1.0",
			"con 0 setserversetting \"PlayerEncumbranceMultiplier\" 1.0",
			"con 0 setserversetting \"FuelBurnTimeMultiplier\" 1.0",
			"con 0 setserversetting \"DogsOfTheDesertSpawnWithDogs\" False",
			"con 0 setserversetting \"NPCMaxSpawnCapMultiplier\" 1.0",
			"con 0 setserversetting \"MinionDamageMultiplier\" 1.0",
			"con 0 setserversetting \"MinionDamageTakenMultiplier\" 1.0",
			"con 0 setserversetting \"MaxAggroRange\" 9000.0",
			"con 0 setserversetting \"ItemConvertionMultiplier\" 1.0",
			"con 0 setserversetting \"PlayerXPCraftMultiplier\" 1.0"
		};

		private static string[] seasond1setting = new string[]
		{
			"con 0 setserversetting \"DayTimeSpeedScale\" 0.7",
			"con 0 setserversetting \"NightTimeSpeedScale\" 1.3",
			"con 0 setserversetting \"HarvestAmountMultiplier\" 1.0",
			"con 0 setserversetting \"ResourceRespawnSpeedMultiplier\" 1.0",
			"con 0 setserversetting \"FuelBurnTimeMultiplier\" 1.0",
			"con 0 setserversetting \"PlayerSprintSpeedScale\" 1.0",
			"con 0 setserversetting \"PlayerStaminaCostMultiplier\" 0.8",
			"con 0 setserversetting \"PlayerActiveThirstMultiplier\" 1.5",
			"con 0 setserversetting \"PlayerActiveHungerMultiplier\" 1.0",
			"con 0 setserversetting \"PlayerEncumbranceMultiplier\" 1.0",
			"con 0 setserversetting \"FuelBurnTimeMultiplier\" 2.0",
			"con 0 setserversetting \"DogsOfTheDesertSpawnWithDogs\" True",
			"con 0 setserversetting \"NPCMaxSpawnCapMultiplier\" 2.0",
			"con 0 setserversetting \"MinionDamageMultiplier\" 1.5",
			"con 0 setserversetting \"MinionDamageTakenMultiplier\" 2.0",
			"con 0 setserversetting \"MaxAggroRange\" 18000.0",
			"con 0 setserversetting \"ItemConvertionMultiplier\" 1.0",
			"con 0 setserversetting \"PlayerXPCraftMultiplier\" 1.0"
		};

		private static string[] seasond2setting = new string[]
		{
			"con 0 setserversetting \"DayTimeSpeedScale\" 0.3",
			"con 0 setserversetting \"NightTimeSpeedScale\" 2.2",
			"con 0 setserversetting \"HarvestAmountMultiplier\" 1.5",
			"con 0 setserversetting \"ResourceRespawnSpeedMultiplier\" 1.5",
			"con 0 setserversetting \"FuelBurnTimeMultiplier\" 1.0",
			"con 0 setserversetting \"PlayerSprintSpeedScale\" 0.8",
			"con 0 setserversetting \"PlayerStaminaCostMultiplier\" 1.2",
			"con 0 setserversetting \"PlayerActiveThirstMultiplier\" 3.0",
			"con 0 setserversetting \"PlayerActiveHungerMultiplier\" 1.5",
			"con 0 setserversetting \"PlayerEncumbranceMultiplier\" 1.6",
			"con 0 setserversetting \"FuelBurnTimeMultiplier\" 1.0",
			"con 0 setserversetting \"DogsOfTheDesertSpawnWithDogs\" False",
			"con 0 setserversetting \"NPCMaxSpawnCapMultiplier\" 1.0",
			"con 0 setserversetting \"MinionDamageMultiplier\" 1.2",
			"con 0 setserversetting \"MinionDamageTakenMultiplier\" 1.4",
			"con 0 setserversetting \"MaxAggroRange\" 9000.0",
			"con 0 setserversetting \"ItemConvertionMultiplier\" 1.0",
			"con 0 setserversetting \"PlayerXPCraftMultiplier\" 1.0"
		};

		private static string[] seasond3setting = new string[]
		{
			"con 0 setserversetting \"DayTimeSpeedScale\" 2.2",
			"con 0 setserversetting \"NightTimeSpeedScale\" 0.5",
			"con 0 setserversetting \"HarvestAmountMultiplier\" 0.7",
			"con 0 setserversetting \"ResourceRespawnSpeedMultiplier\" 0.7",
			"con 0 setserversetting \"FuelBurnTimeMultiplier\" 0.5",
			"con 0 setserversetting \"PlayerSprintSpeedScale\" 0.6",
			"con 0 setserversetting \"PlayerStaminaCostMultiplier\" 1.6",
			"con 0 setserversetting \"PlayerActiveThirstMultiplier\" 1.0",
			"con 0 setserversetting \"PlayerActiveHungerMultiplier\" 1.9",
			"con 0 setserversetting \"PlayerEncumbranceMultiplier\" 1.2",
			"con 0 setserversetting \"FuelBurnTimeMultiplier\" 1.0",
			"con 0 setserversetting \"DogsOfTheDesertSpawnWithDogs\" False",
			"con 0 setserversetting \"NPCMaxSpawnCapMultiplier\" 1.0",
			"con 0 setserversetting \"MinionDamageMultiplier\" 0.7",
			"con 0 setserversetting \"MinionDamageTakenMultiplier\" 0.7",
			"con 0 setserversetting \"MaxAggroRange\" 6000.0",
			"con 0 setserversetting \"ItemConvertionMultiplier\" 1.3",
			"con 0 setserversetting \"PlayerXPCraftMultiplier\" 1.3"
		};
	}
}
