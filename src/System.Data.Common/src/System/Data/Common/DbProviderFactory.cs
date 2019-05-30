// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Data.Common
{
    public abstract partial class DbProviderFactory
    {
        private bool? _canCreateDataAdapter;
        private bool? _canCreateCommandBuilder;

        protected DbProviderFactory() { }

        public virtual bool CanCreateDataSourceEnumerator => false;

        public virtual bool CanCreateDataAdapter
        {
            get
            {
                if (!_canCreateDataAdapter.HasValue)
                {
                    var adapter = CreateDataAdapter();
                    if (adapter == null)
                    {
                        _canCreateDataAdapter = false;
                    }
                    else
                    {
                        _canCreateDataAdapter = true;
                        adapter.Dispose();
                    }
                }

                return _canCreateDataAdapter.Value;
            }
        }

        public virtual bool CanCreateCommandBuilder
        {
            get
            {
                if (!_canCreateCommandBuilder.HasValue)
                {
                    var builder = CreateCommandBuilder();
                    if (builder == null)
                    {
                        _canCreateCommandBuilder = false;
                    }
                    else
                    {
                        _canCreateCommandBuilder = true;
                        builder.Dispose();
                    }
                }

                return _canCreateCommandBuilder.Value;
            }
        }

        public virtual DbCommand CreateCommand() => null;

        public virtual DbCommandBuilder CreateCommandBuilder() => null;

        public virtual DbConnection CreateConnection() => null;

        public virtual DbConnectionStringBuilder CreateConnectionStringBuilder() => null;

        public virtual DbDataAdapter CreateDataAdapter() => null;

        public virtual DbParameter CreateParameter() => null;

        public virtual DbDataSourceEnumerator CreateDataSourceEnumerator() => null;
    }
}
