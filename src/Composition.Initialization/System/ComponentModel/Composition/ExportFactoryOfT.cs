// -----------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// -----------------------------------------------------------------------
using System;
using Microsoft.Internal;
using System.ComponentModel.Composition.Primitives;

namespace System.ComponentModel.Composition
{
    public class ExportFactory<T>
    {
        private Func<Tuple2<T, Action>> _exportLifetimeContextCreator;

        public ExportFactory(Func<Tuple2<T, Action>> exportLifetimeContextCreator)
        {
            if (exportLifetimeContextCreator == null)
            {
                throw new ArgumentNullException("exportLifetimeContextCreator");
            }

            this._exportLifetimeContextCreator = exportLifetimeContextCreator;
        }

        public ExportLifetimeContext<T> CreateExport()
        {
            Tuple2<T, Action> untypedLifetimeContext = this._exportLifetimeContextCreator.Invoke();
            return new ExportLifetimeContext<T>(untypedLifetimeContext.Item1, untypedLifetimeContext.Item2);
        }
    }
}
