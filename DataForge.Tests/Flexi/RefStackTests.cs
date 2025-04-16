using Xunit;
using DataForge.src.Flexi;

namespace DataForge.Tests.Flexi
{
    public class RefStackTests
    {
        private RefStack<int> _stack;

        [Fact]
        public void InsertValues()
        {
            _stack = new RefStack<int>(1);
            _stack.PutOn(2);
            _stack.PutOn(3);
            
            Assert.Equal(3, _stack.Count);
            Assert.Equal("3 2 1 ",_stack.ToString());
        }

        [Fact]
        public void RipValues()
        {
            _stack = new RefStack<int>(1);
            _stack.PutOn(2);

            _stack.RipOff();
        
            Assert.Equal(1, _stack.Count);

            _stack.RipOff();
            Assert.Equal(0, _stack.Count);

            Assert.Equal("empty", _stack.ToString());
        }

        [Fact]
        public void RipValuesCatchError()
        {
            _stack = new RefStack<int>();

            Assert.Throws<InvalidOperationException>(()=> _stack.RipOff());
        }

    }
}
