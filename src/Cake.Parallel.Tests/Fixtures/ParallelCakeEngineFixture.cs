using System;
using System.Collections.Generic;
using System.Text;
using Cake.Core;
using Cake.Core.IO;
using Cake.Parallel.Module;
using Cake.Parallel.Tests.Utilities;
using NSubstitute;

namespace Cake.Parallel.Tests.Fixtures
{
    internal sealed class ParallelCakeEngineFixture
    {
        public IFileSystem FileSystem { get; set; }
        public ICakeEnvironment Environment { get; set; }
        public FakeLog Log { get; set; }
        public IGlobber Globber { get; set; }
        public ICakeArguments Arguments { get; set; }
        public IProcessRunner ProcessRunner { get; set; }
        public ICakeContext Context { get; set; }
        public IExecutionStrategy ExecutionStrategy { get; set; }

        public ParallelCakeEngineFixture()
        {
            FileSystem = Substitute.For<IFileSystem>();
            Environment = Substitute.For<ICakeEnvironment>();
            Log = new FakeLog();
            Globber = Substitute.For<IGlobber>();
            Arguments = Substitute.For<ICakeArguments>();
            ProcessRunner = Substitute.For<IProcessRunner>();
            ExecutionStrategy = new DefaultExecutionStrategy(Log);

            Context = Substitute.For<ICakeContext>();
            Context.Arguments.Returns(Arguments);
            Context.Environment.Returns(Environment);
            Context.FileSystem.Returns(FileSystem);
            Context.Globber.Returns(Globber);
            Context.Log.Returns(Log);
            Context.ProcessRunner.Returns(ProcessRunner);
        }

        public ParallelCakeEngine CreateEngine()
        {
            return new ParallelCakeEngine(Log);
        }
    }
}
