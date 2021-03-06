﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.UI;
using gsec.model.managers;
using NetTopologySuite.Geometries;

namespace gsec.model
{
    public class Road : IDisplayableGeoElement, IPersistable
    {
        public virtual long ID { get; set; }
        public virtual Crossing Source { get; set; }
        public virtual Crossing Target { get; set; }
        public virtual double Length { get; set; }
        public virtual LineString Geom { get; set; }
        
        public Graphic Graphic { get; set; }

        public override bool Equals(object obj)
        {
            var road = obj as Road;
            return road != null &&
                   ID == road.ID;
        }

        public override int GetHashCode()
        {
            return 1213502048 + ID.GetHashCode();
        }

        public void Delete()
        {
            RoadManager.Instance.Delete(this);
        }

        public void Create()
        {
            RoadManager.Instance.Create(this);
        }

        public void Update()
        {
            RoadManager.Instance.Update(this);
        }
    }
}
