using System;
using System.Collections.Generic;
using System.Linq;

namespace FacadDesignPattern
{
    internal partial class Program
    {

        static void Main(string[] args)
        {
            ITower towerMehrabad = new Mehrabad();
            AirBus airBus = new AirBus("001", towerMehrabad);






            /////
            Console.ReadLine();
        }
    }
    public interface ITower
    {
        List<AirPlain> AirPlains { get; set; }

        void Rergister(AirPlain airPlain);
        void Remove(AirPlain airPlain);
    }

    public class Mehrabad : ITower
    {
        public List<AirPlain> AirPlains { get; set; } = new List<AirPlain>();

        public void Remove(AirPlain airPlain)
        {
            AirPlains.Remove(airPlain);
        }

        public void Rergister(AirPlain airPlain)
        {
            AirPlains.Add(airPlain);
        }
    }

    public abstract class AirPlain : IDisposable
    {
        private readonly ITower _tower;
        public AirPlain(ITower tower)
        {
            _tower = tower;
            _tower.Rergister(this);

        }
        public string Name { get; set; }
        public int AcceptableDistaance { get; set; }

        public void Dispose()
        {
            _tower.Remove(this);
        }




    }






    public class AirBus : AirPlain
    {
        public AirBus(string uniqName, ITower tower) : base(tower)
        {
            Name = $"Airbs {uniqName}";
            AcceptableDistaance = 1000;
        }
    }
    public class Foker : AirPlain
    {
        public Foker(string uniqName, ITower tower) : base(tower)
        {
            Name = $"Foker {uniqName}";
            AcceptableDistaance = 500;
        }
    }
    public class Topolof : AirPlain
    {
        public Topolof(string uniqName, ITower tower) : base(tower)
        {
            Name = $"Airbs {uniqName}";
            AcceptableDistaance = 200;
        }
    }
}