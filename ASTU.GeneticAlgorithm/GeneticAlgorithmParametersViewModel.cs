using Sparrow.Chart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTU.GeneticAlgorithm
{
    public class GeneticAlgorithmParametersViewModel : Observable
    {
        public GeneticAlgorithmParametersViewModel()
        {
            _averageFitness.Add(new DoublePoint() { Data = 0, Value = 10 });
            _averageFitness.Add(new DoublePoint() { Data = 1, Value = 20 });
            _averageFitness.Add(new DoublePoint() { Data = 2, Value = 30 });

            _maxFitness.Add(new DoublePoint() { Data = 0, Value = 11 });
            _maxFitness.Add(new DoublePoint() { Data = 1, Value = 22 });
            _maxFitness.Add(new DoublePoint() { Data = 2, Value = 33 });

            _minFitness.Add(new DoublePoint() { Data = 0, Value = 9 });
            _minFitness.Add(new DoublePoint() { Data = 1, Value = 18 });
            _minFitness.Add(new DoublePoint() { Data = 2, Value = 28 });
        }
        private GeneticAlgoritmParameters _geneticParameters = new GeneticAlgoritmParameters();        
        public int InitialPopulationSize
        {
            get
            {
                return _geneticParameters.InitialPopulationSize;
            }
            set
            {
                _geneticParameters.InitialPopulationSize = value;
                NotifyPropertyChanged(()=>InitialPopulationSize);
            }
        }
        public int GenerationCount
        {
            get
            {
                return _geneticParameters.GenerationCount;
            }
            set
            {
                _geneticParameters.GenerationCount = value;
                NotifyPropertyChanged(() => GenerationCount);
            }
        }
        public int ReproductionNumber
        {
            get
            {
                return _geneticParameters.ReproductionNumber;
            }
            set
            {
                _geneticParameters.ReproductionNumber = value;
                NotifyPropertyChanged(() => ReproductionNumber);
            }
        }
        public int MutationProbability
        {
            get
            {
                return _geneticParameters.MutationProbability;
            }
            set
            {
                _geneticParameters.MutationProbability = value;
                NotifyPropertyChanged(() => MutationProbability);
            }
        }
        public int GoodOrganizmSurvivalProbability
        {
            get
            {
                return _geneticParameters.GoodOrganizmSurvivalProbability;
            }
            set
            {
                _geneticParameters.GoodOrganizmSurvivalProbability = value;
                NotifyPropertyChanged(() => GoodOrganizmSurvivalProbability);
            }
        }
        public int BadOrganizmDeathProbability
        {
            get
            {
                return _geneticParameters.BadOrganizmDeathProbability;
            }
            set
            {
                _geneticParameters.BadOrganizmDeathProbability = value;
                NotifyPropertyChanged(() => BadOrganizmDeathProbability);
            }
        }

        private int _gridStep;

        public int GridStep
        {
            get
            {
                return _gridStep;
            }
            set
            {
                _gridStep = value;
                NotifyPropertyChanged(() => GridStep);
            }
        }
        private PointsCollection _averageFitness = new PointsCollection();
        public PointsCollection AverageFitness
        {
            get
            {
                return _averageFitness;
            }
            set
            {
                _averageFitness = value;
                NotifyPropertyChanged(() => AverageFitness);
            }
        }

        private PointsCollection _minFitness = new PointsCollection();
        public PointsCollection MinFitness
        {
            get
            {
                return _minFitness;
            }
            set
            {
                _minFitness = value;
                NotifyPropertyChanged(() => MinFitness);
            }
        }

        private PointsCollection _maxFitness = new PointsCollection();
        public PointsCollection MaxFitness
        {
            get
            {
                return _maxFitness;
            }
            set
            {
                _maxFitness = value;
                NotifyPropertyChanged(() => MaxFitness);
            }
        }

    }
}
