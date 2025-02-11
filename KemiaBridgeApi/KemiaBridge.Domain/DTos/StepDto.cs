﻿namespace KemiaBridge.Domain.DTos
{
    public class StepDto
    {
        public int StepId { get; private set; }
        public string Name { get; set; } = null!;
        public string Icon { get; set; } = null!;
        public int StationId { get; private set; }

        public void SetNewId(int id)
        {
            StepId = id;
        }

        public void SetStationId(int id) { 
            StationId = id;
        }
    }
}
