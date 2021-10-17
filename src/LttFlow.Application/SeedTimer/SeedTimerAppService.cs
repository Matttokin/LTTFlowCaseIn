using Abp.Application.Services;
using Abp.Domain.Repositories;
using LttFlow.MeterReading;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LttFlow.SeedTimer
{
    public class SeedTimerAppService : LttFlowAppServiceBase, ISeedTimerAppService
    {
        private StandartGroupSensor[] _standartGroups;
        private StandartSensor[] _standartSensors;

        private readonly int
            _minValueSensor,
            _maxValueSensor;

        private Timer _timer;
        private readonly Random _rnd;
        private readonly IRepository<MeterReadingList, long> _meterReadingRepository;
        private readonly IRepository<MeterReadingGroupList, long> _meterReadingGroupListRepository;

        public SeedTimerAppService(IRepository<MeterReadingList, long> meterReadingRepository, IRepository<MeterReadingGroupList, long> meterReadingGroupListRepository)
        {
            _meterReadingRepository = meterReadingRepository;
            _meterReadingGroupListRepository = meterReadingGroupListRepository;

            _minValueSensor = 0;
            _maxValueSensor = 30;

            _rnd = new Random();

            InitData();
            InsertStandartGroups();
        }
        private void InitData()
        {
            _standartGroups = new StandartGroupSensor[3]
            {
                new StandartGroupSensor("RO","Ростовская область"),
                new StandartGroupSensor("KRKR","Краснодарский край"),
                new StandartGroupSensor("MOSOBL","Московская область")
            };

            _standartSensors = new StandartSensor[30];
            int groupId = 0;
            for (int i = 0; i < 30; i++)
            {
                _standartSensors[i] = new StandartSensor(i.ToString(), $"Датчик №{i + 1}", groupId++, "");
            }
        }

        private void InsertStandartGroups()
        {
            if(_meterReadingGroupListRepository.Count() == 0)
            {
                for (int i = 0; i < _standartGroups.Length; i++)
                {
                    _meterReadingGroupListRepository.Insert(new MeterReadingGroupList { Alias = _standartGroups[i].Alias, Name = _standartGroups[i].Name });
                }
            }
        }

        private void GenerateData(object obj)
        {
            foreach(var sensor in _standartSensors)
            {
                _meterReadingRepository.Insert(new MeterReadingList()
                {
                    GIUD = sensor.GIUD,
                    Name = sensor.Name,
                    GroupId = sensor.GroupId,
                    Location = sensor.Location,
                    Value = GetRandomValueSensor(_minValueSensor, _maxValueSensor),
                    Time = DateTime.Now
                });
            }
        }

        private decimal GetRandomValueSensor(int min, int max)
        {
            return (decimal)_rnd.NextDouble() * (max - min) + min;
        }

        public void GenerateData()
        {
            _timer = new Timer((obj) => GenerateData(obj), null, 0, 60 * 1000);
        }
    }

    public class StandartSensor
    {
        public string GIUD { get; private set; } //20 символов
        public string Name { get; private set; } //Источник 1 и тд
        public int GroupId { get; private set; } //Группа, крытый двор и тд
        public string Location { get; private set; }  //
        public decimal Value { get; private set; } // 10 до 30 
        public DateTime Time { get; private set; }

        public void UpdateSensorData(decimal value, DateTime dateTime)
        {
            Value = value;
            Time = dateTime;
        }
        public StandartSensor(string gIUD, string name, int groupId, string location)
        {
            GIUD = gIUD;
            Name = name;
            GroupId = groupId;
            Location = location;
        }
    }

    public class StandartGroupSensor
    {
        public string Alias { get; private set; }
        public string Name { get; private set; }
        public StandartGroupSensor(string alias, string name)
        {
            Alias = alias;
            Name = name;
        }
    }
}
