﻿using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.UI;
using gsec.model.managers;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace gsec.model
{
    public class Sensor : IDisplayableGeoElement, IPersistable
    {
        public virtual long ID { get; set; }
        public virtual Point Position { get; set; }

        public static int Range { get; set; } = 250;

        public Graphic Graphic { get; set; }
        public Graphic RangeGraphic { get; set; }
        public Graphic AlarmGraphic { get; set; }

        public MapPoint EsriPosition { get { return Graphic.Geometry as MapPoint; } }

        public Sensor()
        {
        }

        public override bool Equals(object obj)
        {
            var sensor = obj as Sensor;
            return sensor != null &&
                   ID == sensor.ID;
        }

        public override int GetHashCode()
        {
            return 1213502048 + ID.GetHashCode();
        }
        
        public void Delete()
        {
            SensorManager.Instance.Delete(this);
        }

        public void Create()
        {
            SensorManager.Instance.Create(this);
        }

        public void Update()
        {
            SensorManager.Instance.Update(this);
        }
    }
}
