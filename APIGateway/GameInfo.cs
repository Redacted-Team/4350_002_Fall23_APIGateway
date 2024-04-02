﻿namespace Gateway
{
    public class GameInfo
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string DateAdded { get; set; }
        public string HowTo { get; set; }
        public Stack<KeyValuePair<string, int>> LeaderBoardStack { get; set; }
    }
}