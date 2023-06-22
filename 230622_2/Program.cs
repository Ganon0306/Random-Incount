using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230622_2
{
    internal class Program
    {

        static char[,] map = new char[20 + 2, 20 + 2];

        static int PlayerX = 11;
        static int PlayerY = 1;
        static int PlayerHp = 100;


        static int Quest = 0;
        static int QuestX = 18;
        static int QuestY = 4;

        static int Bug = 0;
        static int BugHP = 50;

        static bool End = false;

        static int Guard = 0;
        static int GuardX = 8;
        static int GuardY = 20;


        static void Main(string[] args)
        {
            while (true)
            {
                Drow_Map();

                Console.WriteLine("{0}, {1}", PlayerX, PlayerY);
                Move();
                if (End == true)
                {
                    break;
                }
            }
        }

        static void Drow_Map()
        {
            for (int i = 0; i < 20 +2; i++)
            {
                for(int j = 0; j < 20 +2; j++)
                {
                    if ((i == 7 && j > 0) && j < 20)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("■");
                        Console.ResetColor();
                    }
                    else if (i == 0 || i == 20 + 1 || j == 0 || j == 20 + 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("■");
                        Console.ResetColor();
                    }
                    else if (i == PlayerX && j == PlayerY)
                    {
                        if (i >= 1 && i <= 6)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }

                        Console.Write("★");
                        Console.ResetColor();
                    }
                    else if (i >= 1 && i <= 6)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("†");
                        Console.ResetColor();
                    }
                    else if (i == QuestX && j == QuestY)                    //퀘스트
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("●");
                        Console.ResetColor();
                    }
                    else if (i == GuardX && j == GuardY) 
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("●");
                        Console.ResetColor();
                    }                    
                    else
                    {
                        map[i, j] = '□';
                        Console.Write("{0}", map[i, j]);
                    }
                }

                Console.WriteLine();
            }
        }

        static void Move()
        {
            ConsoleKeyInfo KeyInfo = Console.ReadKey();
            char move = KeyInfo.KeyChar;

            if (move == 'a')
            {
                if (PlayerY > 1 && !(PlayerX == 7 && PlayerY - 1 >= 1 && PlayerY - 1 <= 19))
                {
                    if (PlayerX == QuestX && PlayerY-1 == QuestY)
                    {
                        QuestNPC();
                    }
                    else if (PlayerX == GuardX && PlayerY - 1 == GuardY)
                    {
                        GuardNPC();
                    }
                    else
                    {
                        PlayerY -= 1;
                    }
                    InCount();
                }
            }
            else if (move == 'd')
            {
                if (PlayerY < 20 && !(PlayerX == 7 && PlayerY + 1 >= 1 && PlayerY + 1 <= 19))
                {
                    if (PlayerX == QuestX && PlayerY+1 == QuestY)
                    {
                        QuestNPC();
                    }
                    else if (PlayerX == GuardX && PlayerY + 1 == GuardY)
                    {
                        GuardNPC();
                    }
                    else
                    {
                        PlayerY += 1;
                    }
                    InCount();
                }
            }
            else if (move == 'w')
            {
                if (PlayerX > 1 && !(PlayerX - 1 == 7 && PlayerY >= 1 && PlayerY <= 19))
                {
                    if (PlayerX-1 == QuestX && PlayerY == QuestY)
                    {
                        QuestNPC();
                    }
                    else if (PlayerX-1 == GuardX && PlayerY == GuardY)
                    {
                        GuardNPC();
                    }
                    else
                    {
                        PlayerX -= 1;
                    }
                    InCount();
                }
            }
            else if (move == 's')
            {
                if (PlayerX < 20 && !(PlayerX + 1 == 7 && PlayerY >= 1 && PlayerY <= 19))
                {
                    if (PlayerX+1 == QuestX && PlayerY == QuestY)
                    {
                        QuestNPC();
                    }
                    else if (PlayerX +1== GuardX && PlayerY == GuardY)
                    {
                        GuardNPC();
                    }
                    else
                    {
                        PlayerX += 1;
                    }
                    InCount();
                }
            }
            Console.SetCursorPosition(0, 0);
        }

        static void QuestNPC()
        {
            //퀘스트 주는놈
            Console.SetCursorPosition(50, 10);
            if (Quest == 0)
            {
                Console.WriteLine("풀벌레를 잡아와줘.");

                ConsoleKeyInfo KeyInfo = Console.ReadKey();
                Quest = 1;
            }
            else if (Quest == 1 && Bug < 5)
            {
                Console.WriteLine("아직 멀었어? 언제까지 기다려야 되는 거야?");

                ConsoleKeyInfo KeyInfo = Console.ReadKey();
            }
            else if (Bug == 5)
            {
                Console.WriteLine("왜 이렇게 오래 걸린 거야? 이런 쉬운것도 제대로 못해?");

                ConsoleKeyInfo KeyInfo = Console.ReadKey();
                Console.SetCursorPosition(50, 10);
                Console.WriteLine("뭘 멍하니 있는거야. 이제 볼일은 없으니 돌아가.");
                KeyInfo = Console.ReadKey();
                End = true;
            }
            Console.Clear();

        }

        static void GuardNPC()
        {
            //가드          
            Console.SetCursorPosition(50, 10);
            if (Quest == 0 && Guard == 0)
            {
                Console.WriteLine("볼일이 없다면 들어가지 않는게 좋아.");
                ConsoleKeyInfo KeyInfo = Console.ReadKey();
            }
            if (Quest == 1 && Guard == 0)
            {
                Console.WriteLine("너도 힘들겠구나.");
                ConsoleKeyInfo KeyInfo = Console.ReadKey();
                GuardY -= 1;
                Guard = 1;
            }
            else if (Guard == 1)
            {
                Console.WriteLine("아무리 풀벌레라지만 조심하는게 좋아. 회복이 필요하면 나한테 와.");
                ConsoleKeyInfo KeyInfo = Console.ReadKey();
                
            }
            else if(Guard == 1 && PlayerHp < 50)
            {
                Console.WriteLine("치료가 필요해 보이네. 좀 쉬다 가.");
                PlayerHp = 100;

            }
            Console.Clear();
        }

        //static void InCount()
        //{
        //    if (PlayerX <= 6)
        //    {
        //        Console.SetCursorPosition(50, 10);

        //        Random rnd = new Random();
        //        int a = rnd.Next(0, 100);
        //        if (a < 36)
        //        {
        //            if (Bug < 5)
        //            {
        //                Bug += 1;
        //                Console.WriteLine("잡은 풀벌레 수 {0}", Bug);
        //            }
        //            else
        //            {
        //                Console.WriteLine("벌레를 다 잡았다. 돌아가자.");
        //            }
        //        }
        //    }
        //}

        static void InCount()
        {
            if (PlayerX <= 6)
            {
                Console.SetCursorPosition(50, 9);

                Random rnd = new Random();
                int a = rnd.Next(0, 100);
                if (a < 20)
                {
                    Console.WriteLine("풀벌레가 나타났다!!");
                    ConsoleKeyInfo KeyInfo = Console.ReadKey();
                    while (PlayerHp > 0 && BugHP > 0) // 두 조건 모두 충족할 때까지 전투를 반복합니다.
                    {
                        Console.Clear();
                        Console.SetCursorPosition(50, 10);
                        Console.WriteLine("1. 평범한 공격 ");
                        Console.SetCursorPosition(50, 11);
                        Console.WriteLine("2. 강한 공격");
                        Console.SetCursorPosition(50, 12);
                        Console.WriteLine("3. 빠른 공격");

                        KeyInfo = Console.ReadKey();
                        char attack = KeyInfo.KeyChar;

                        switch (attack)
                        {
                            case '1':
                                Console.Clear();
                                Console.SetCursorPosition(50, 11);
                                Console.WriteLine("공격 성공! 적에게 10의 데미지!");
                                BugHP -= 10;
                                Console.SetCursorPosition(50, 12);
                                Console.WriteLine("적의 공격! 나에게 10의 데미지!");
                                PlayerHp -= 10;
                                break;

                            case '2':
                                int PlayerHardValue = rnd.Next(0, 10);
                                Console.Clear();
                                Console.SetCursorPosition(50, 10);
                                Console.WriteLine("적에게 강한 공격!");

                                if (PlayerHardValue < 3)
                                {
                                    Console.SetCursorPosition(50, 11);
                                    Console.WriteLine("공격 성공! 적에게 20의 데미지!");
                                    BugHP -= 20;
                                    Console.SetCursorPosition(50, 12);
                                    Console.WriteLine("적의 공격! 나에게 10의 데미지!");
                                    PlayerHp -= 10;
                                }
                                else
                                {
                                    Console.SetCursorPosition(50, 12);
                                    Console.WriteLine("공격이 빗나갔다....");
                                    Console.SetCursorPosition(50, 13);
                                    Console.WriteLine("적의 공격! 나에게 10의 데미지!");
                                    PlayerHp -= 10;
                                }
                                break;

                            case '3':
                                int PlayerSpeedValue = rnd.Next(6, 14);
                                Console.Clear();
                                Console.SetCursorPosition(50, 10);
                                Console.WriteLine("적에게 빠른 공격!");
                                Console.SetCursorPosition(50, 11);
                                Console.WriteLine("공격 성공! 적에게 {0}의 데미지!", PlayerSpeedValue);
                                BugHP -= PlayerSpeedValue;
                                Console.SetCursorPosition(50, 12);
                                Console.WriteLine("적의 공격! 나에게 10의 데미지!");
                                PlayerHp -= 10;
                                break;
                        }

                        Console.SetCursorPosition(50, 15);
                        Console.WriteLine("나의 HP {0}", PlayerHp);
                        Console.SetCursorPosition(50, 16);
                        Console.WriteLine("적의 HP {0}", BugHP);
                        KeyInfo = Console.ReadKey();
                        Console.SetCursorPosition(50, 10);

                    }
                    if(PlayerHp <= 0)
                    {
                        Console.WriteLine("'벌레'에게 패배했다....");
                        End = true;
                    }
                    else if (BugHP <= 0)
                    {
                        Console.WriteLine("적에게 승리했다!!");
                        Bug += 1;
                        BugHP = 50;
                        Console.WriteLine("잡은 풀벌레 수 {0}", Bug);
                    }
                    if (Bug >= 5)
                    {
                        Console.WriteLine("벌레를 다 잡았다. 돌아가자.");
                    }

                    Console.Clear();
                }
            }
        }





    }
}
