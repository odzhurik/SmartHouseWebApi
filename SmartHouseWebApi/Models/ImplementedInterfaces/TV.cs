﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartHouseMVC.Models.Interfaces;
namespace SmartHouseMVC.Models.ImplementedInterfaces
{
    public class TV : Applience, IChannel, IChangeable
    {
        public IList<string> channels;
        public string currentChannel;
        int max;

        public int Max
        {
            get { return max; }
            set { max = value; }
        }

        public TV()
        {

        }
        public TV(string name, int unit, int max, IList<string> listOfChannels, int positionOfCurrentChan)
        {
            Name = name;
            channels = listOfChannels;
            currentChannel = channels.ElementAt(positionOfCurrentChan);
            Unit = unit;
            this.max = max;
        }
        public int Unit
        {
            get;
            set;
        }

        public IList<string> ShowChannels()
        {
            if (this.State)
                return channels;
            else
                return null;
        }
        public void AddChannel(string channel)
        {

            channels.Add(channel);
        }
        public void Up()
        {
            if (State)
            {
                if (Unit == max)
                    Unit = 0;
                else
                    Unit++;
            }
        }
        public void Down()
        {
            if (State)
            {
                if (Unit == 0)
                    Unit = max;
                else
                    Unit--;
            }
        }
        public override string ToString()

        {
            string status = base.ToString();

            if (State)
                status += " current volume " + Unit + " current channel " + currentChannel;

            return status;
        }
        public void NextChannel()
        {
            if (State)
            {
                int index = channels.IndexOf(currentChannel);
                if(currentChannel=="none")
                {
                    return;
                }
                if (index == (channels.Count - 1))
                    currentChannel = channels[0];
                else
                    currentChannel = channels[++index];
            }
        }
        public void PrevChannel()
        {
            if (State)
            {
                int index = channels.IndexOf(currentChannel);
                if(currentChannel=="none")
                {
                    return;
                }
                if (index == 0)
                    currentChannel = channels[channels.Count - 1];
                else
                    currentChannel = channels[--index];
            }
        }
        public void DeleteCurrentCh()
        {
            if (State)
            {
                bool flag = false;
                int pos = channels.IndexOf(currentChannel);

                if(currentChannel=="none")
                {
                    return;
                }
                if ((pos + 1) == channels.Count)
                {
                    currentChannel = channels[0];
                    flag = true;
                }


                if ((pos + 1) == channels.Count && channels.Count == 1)
                {

                    currentChannel = "none";
                    flag = true;
                }

                if (!flag)
                {
                    currentChannel = channels[pos + 1];
                }
                channels.RemoveAt(pos);
            }
        }
    }
}