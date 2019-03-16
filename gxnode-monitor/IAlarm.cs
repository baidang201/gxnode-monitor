using System;
namespace gxnode_monitor
{
    public enum AlarmLevel
    {
        info = 0,
        warn = 1,
        error = 2
    }

    public interface IAlarm
    {
        void Alarm(AlarmLevel level, string msg);
    }
}

