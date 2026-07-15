//using System;
//using NEAPROJECT.Controls;

//namespace NEAPROJECT.CustomQueues
//{
//    public class MapCircularQueue
//    {
//        private Button[] _maps;
//        private int _front;
//        private int _rear;
//        private Button _currentMap;

//        public Button CurrentMap { get => _currentMap; set => _currentMap = value; }

//        public MapCircularQueue()
//        {
//            _maps = new Button[3];
//            _front = 0;
//            _rear = -1;
//        }

//        public void Enqueue(Button newMap)
//        {
//            _rear = (_rear + 1) % 3;
//            _maps[_rear] = newMap;
//            _currentMap = newMap;
//        }

//        public void Dequeue()
//        {
//            _front = (_front + 1) % 3;
//            _maps[_rear] = _currentMap;
//            _currentMap = _maps[_front];
//        }
//    }
//}

