using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Failsafe
{
    public enum CoolantSystemStatus
    {
        OK,
        Check,
        Fail
    }

    public enum SuccessFailureResult
    {
        Success,
        Fail
    }

    public class Switch
    {
        /// <summary>
        /// Утилитарный объект для симуляции
        /// </summary>
        private Random rand = new Random();

        /// <summary>
        /// Отключение от внешних систем генерации энергии
        /// </summary>
        /// <returns>Успех или неудача</returns>
        /// <exception cref="PowerGeneratorCommsException">
        /// Выбрасывается при неудачной попытке подключения к системе генерации энергии
        /// </exception>
        public SuccessFailureResult DisconnectPowerGenerator()
        {
            if (rand.Next(1, 10) > 2)
                return SuccessFailureResult.Success;

            if (rand.Next(1, 20) > 18)
                throw new PowerGeneratorCommsException("Ошибка сети при доступе к системе генерации энергии");

            return SuccessFailureResult.Fail;
        }

        /// <summary>
        /// Диагностика основной системы охлаждения
        /// </summary>
        /// <returns>Статус системы охлаждения: OK, Fail или Check</returns>
        /// <exception cref="CoolantTemperatureReadException">Не удалось считать температуру системы охлаждения</exception>
        /// <exception cref="CoolantPressureReadException">Не удалось считать давление системы охлаждения</exception>
        public CoolantSystemStatus VerifyPrimaryCoolantSystem()
        {
            int r = rand.Next(1, 10);
            if (r > 5)
                return CoolantSystemStatus.OK;

            if (r > 2)
                return CoolantSystemStatus.Check;

            if (rand.Next(1, 20) > 18)
                throw new CoolantTemperatureReadException("Не удалось считать температуру основной системы охлаждения");

            if (rand.Next(1, 20) > 18)
                throw new CoolantPressureReadException("Не удалось считать давление основной системы охлаждения");

            return CoolantSystemStatus.Fail;
        }

        /// <summary>
        /// Диагностика резервной системы охлаждения
        /// </summary>
        /// <returns>Статус системы охлаждения: OK, Fail или Check</returns>
        /// <exception cref="CoolantTemperatureReadException">Не удалось считать температуру системы охлаждения</exception>
        /// <exception cref="CoolantPressureReadException">Не удалось считать давление системы охлаждения</exception>
        public CoolantSystemStatus VerifyBackupCoolantSystem()
        {
            int r = rand.Next(1, 10);
            if (r > 5)
                return CoolantSystemStatus.OK;

            if (r > 2)
                return CoolantSystemStatus.Check;

            if (rand.Next(1, 20) > 19)
                throw new CoolantTemperatureReadException("Не удалось считать температуру резервной системы охлаждения");

            if (rand.Next(1, 20) > 19)
                throw new CoolantPressureReadException("Не удалось считать давление резервной системы охлаждения");

            return CoolantSystemStatus.Fail;
        }

        /// <summary>
        /// Чтение температуры из ядра реактора
        /// </summary>
        /// <returns>Температура</returns>
        /// <exception cref="CoreTemperatureReadException">Не удалось получить данные о температуре ядра</exception>
        public double GetCoreTemperature()
        {
            if (rand.Next(1, 20) > 18)
                throw new CoreTemperatureReadException("Не удалось считать температуру ядра реактора");

            return rand.NextDouble() * 1000;
        }

        /// <summary>
        /// Вставка управляющих стержней для остановки реактора
        /// </summary>
        /// <returns>Успех или неудача</returns>
        /// <exception cref="RodClusterReleaseException">Ошибка считывания позиции управляющих стержней</exception>
        public SuccessFailureResult InsertRodCluster()
        {
            if (rand.Next(1, 100) > 5)
                return SuccessFailureResult.Success;

            if (rand.Next(1, 10) > 8)
                throw new RodClusterReleaseException("Ошибка датчика: не удается подтвердить выпуск стержней");

            return SuccessFailureResult.Fail;
        }

        /// <summary>
        /// Чтение уровня радиации из ядра реактора
        /// </summary>
        /// <returns>Уровень радиации</returns>
        /// <exception cref="CoreRadiationLevelReadException">Ошибка при чтении уровня радиации в ядре</exception>
        public double GetRadiationLevel()
        {
            if (rand.Next(1, 20) > 18)
                throw new CoreRadiationLevelReadException("Не удалось считать уровень радиации ядра");

            return rand.NextDouble() * 500;
        }

        /// <summary>
        /// Оповещение о завершении процедуры выключения
        /// </summary>
        /// <exception cref="SignallingException">Ошибка подключения к системе оповещения</exception>
        public void SignalShutdownComplete()
        {
            if (rand.Next(1, 20) > 18)
                throw new SignallingException("Ошибка сети при подключении к системе оповещения");
        }
    }

    // Исключения для различных систем
    public class PowerGeneratorCommsException : Exception
    {
        public PowerGeneratorCommsException(string message) : base(message) { }
    }

    public class CoolantSystemException : Exception
    {
        public CoolantSystemException(string message) : base(message) { }
    }

    public class CoolantTemperatureReadException : CoolantSystemException
    {
        public CoolantTemperatureReadException(string message) : base(message) { }
    }

    public class CoolantPressureReadException : CoolantSystemException
    {
        public CoolantPressureReadException(string message) : base(message) { }
    }

    public class CoreTemperatureReadException : Exception
    {
        public CoreTemperatureReadException(string message) : base(message) { }
    }

    public class CoreRadiationLevelReadException : Exception
    {
        public CoreRadiationLevelReadException(string message) : base(message) { }
    }

    public class RodClusterReleaseException : Exception
    {
        public RodClusterReleaseException(string message) : base(message) { }
    }

    public class SignallingException : Exception
    {
        public SignallingException(string message) : base(message) { }
    }

}
