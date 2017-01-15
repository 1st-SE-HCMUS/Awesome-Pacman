using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
//{
//                System.Media.SoundPlayer SoundSiren = new System.Media.SoundPlayer(Properties.Resources.Siren);
//SoundSiren.PlayLooping();

//            }
namespace PacMan.Controller
{
    class SoundManager
    {
        public enum SOUND { Siren, Death, EatFruit, Beginning, EatGhost, WakaWaka};
        //one sound per time
        System.Media.SoundPlayer SoundSiren;
        System.Media.SoundPlayer SoundBeginning;
        System.Media.SoundPlayer SoundDeath;

        //multil thread sound
        String RootPath;
        const String SoundEatFruitPath = "pacman_eatfruit.wav";
        const String SoundEatGhostPath = "pacman_eatghost.wav";


        public SoundManager()
        {
            RootPath = Environment.CurrentDirectory.ToString();
            RootPath = System.IO.Directory.GetParent(RootPath).ToString();
            RootPath = System.IO.Directory.GetParent(RootPath).ToString();
            RootPath += "\\Resources\\";

            SoundSiren = new System.Media.SoundPlayer(Properties.Resources.Siren_Waka);
            SoundDeath = new System.Media.SoundPlayer(Properties.Resources.pacman_death);
            SoundBeginning = new System.Media.SoundPlayer(Properties.Resources.pacman_beginning);
        }

        // Sound api functions
        [DllImport("winmm.dll")]
        static extern Int32 mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);

        public void Play(SOUND sound, bool loop = false)
        {
            if(loop == false)
            {
                switch (sound)
                {
                    case SOUND.Siren:
                        {
                            SoundSiren.Play();
                            break;
                        }
                    case SOUND.Beginning:
                        {
                            SoundBeginning.Play();
                            break;
                        }
                    case SOUND.Death:
                        {
                            SoundDeath.Play();
                            break;
                        }
                }
            }
            else
            {
                switch (sound)
                {
                    case SOUND.Siren:
                        {
                            SoundSiren.PlayLooping();
                            break;
                        }
                    case SOUND.Beginning:
                        {
                            SoundBeginning.PlayLooping();
                            break;
                        }
                    case SOUND.Death:
                        {
                            SoundDeath.PlayLooping();
                            break;
                        }
                }
            }
           
        }
        public void Stop(SOUND sound)
        {
            switch (sound)
            {
                case SOUND.Siren:
                    {
                        SoundSiren.Stop();
                        break;
                    }
                case SOUND.Beginning:
                    {
                        SoundBeginning.Stop();
                        break;
                    }
                case SOUND.Death:
                    {
                        SoundDeath.Stop();
                        break;
                    }
            }
        }

        public void PlayByNewThread(SOUND sound)
        {
            switch (sound)
            {
                
                case SOUND.EatFruit:
                    {
                        new System.Threading.Thread(() =>
                        {
                            String openCommand = "open \"" + RootPath + SoundEatFruitPath + "\" type waveaudio alias applause"; 
                            mciSendString(openCommand, null, 0, IntPtr.Zero);
                            mciSendString(@"play applause", null, 0, IntPtr.Zero);
                        }).Start();
                        break;
                    }
                case SOUND.EatGhost:
                    {
                        new System.Threading.Thread(() =>
                        {
                            Random rnd = new Random();
                            int track = rnd.Next(0, 400);  // 1 <= month < 13

                            String openCommand = "open \"" + RootPath + SoundEatFruitPath + "\" type waveaudio alias " + track.ToString();
                            mciSendString(openCommand, null, 0, IntPtr.Zero);
                            mciSendString(@"play " + track.ToString(), null, 0, IntPtr.Zero);
                        }).Start();
                        break;
                    }
            }
        }





    }
}
