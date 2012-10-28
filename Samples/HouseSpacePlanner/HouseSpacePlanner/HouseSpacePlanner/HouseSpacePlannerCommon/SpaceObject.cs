//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace HouseSpacePlanner
{
    using System;
    using System.ComponentModel.Composition;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Collections.Generic;

    public interface ISpaceObjectMetadata
    {
        string Name { get; }
        string Type { get; }
    }

    public abstract class SpaceObject : Canvas, IPartImportsSatisfiedNotification
    {
        [Import]
        public IDimensionToPixelConverter PixelConvereter { get; set; }

        public SpaceObject(double width, double height)
        {
            RelativeWidth = width;
            RelativeHeight = height;
            Background = new SolidColorBrush(Colors.Transparent);
            Cursor = Cursors.Hand;
        }

        #region IPartImportsSatisfiedNotification Members
        public virtual void OnImportsSatisfied()
        {
            Width = PixelConvereter.ToPixel(RelativeWidth);
            Height = PixelConvereter.ToPixel(RelativeHeight);
        }
        #endregion

        public void RemoveFromPlanningSurface()
        {
            if (RemoveFromPlanningSurfaceRequested != null)
            {
                RemoveFromPlanningSurfaceRequested(this, new EventArgs());
            }
        }

        public double RelativeWidth { get; set; }
        public double RelativeHeight { get; set; }
        public event EventHandler RemoveFromPlanningSurfaceRequested;

    }

    public class SpaceObjectBindingHelper
    {
        public PartCreator<SpaceObject, ISpaceObjectMetadata> Creator { get; private set; }
        public string Name { get { return Creator.Metadata.Name; } }
        public string ObjectType { get { return Creator.Metadata.Type; } }
        public SpaceObject SpaceObject { get; private set; }

        public SpaceObjectBindingHelper(PartCreator<SpaceObject, ISpaceObjectMetadata> creator)
        {
            Creator = creator;
            SpaceObject = Creator.CreatePart().ExportedValue;
        }
    }
}
