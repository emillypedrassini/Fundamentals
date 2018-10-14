using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest
{
	[TestFixture]
	public class StackTests
	{
		private Stack<string> _stack;

		[SetUp]
		public void SetUp()
		{
			_stack = new Stack<string>();
		}

		[Test]
		public void Push_ArgumentIsNUll_ThrowArgumentNullException()
		{
			//Stack<string> stack = new Stack<string>();

			Assert.That(() => _stack.Push(null),
				Throws.ArgumentNullException);
		}

		[Test]
		public void Push_ArgumentIsValid_AddTheObjectToTheStack()
		{

			//Stack<string> stack = new Stack<string>();

			_stack.Push("a");

			Assert.That(_stack.Count, Is.EqualTo(1));

		}

		[Test]
		public void Count_EmptyStack_ReturnZero()
		{
			//Stack<string> stack = new Stack<string>();

			Assert.That(_stack.Count, Is.EqualTo(0));
		}

		[Test]
		public void Pop_StackIsEmpty_ThrowInvalidOperationException()
		{
			Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
		}

		[Test]
		public void Pop_StackWithAFewObjects_ReturnObjectOnTheTop()
		{
			//Arrange
			_stack.Push("a");
			_stack.Push("b");
			_stack.Push("c");

			//Act
			var result = _stack.Pop();

			//Assert
			Assert.That(result, Is.EqualTo("c"));
		}

		[Test]
		public void Pop_StackWithAFewObjects_RemoveObjectOnTheTop()
		{
			//Arrange
			_stack.Push("a");
			_stack.Push("b");
			_stack.Push("c");

			//Act
			_stack.Pop();

			//Assert
			Assert.That(_stack.Count, Is.EqualTo(2));
		}

		[Test]
		public void Peek_StackIsEmpty_ThrowInvalidOperationException()
		{
			Assert.That(() => _stack.Peek(), Throws.InvalidOperationException);
		}

		[Test]
		public void Peek_StackWithObjects_ReturnObjectOnTopOfTheStack()
		{
			//Arrange
			_stack.Push("a");
			_stack.Push("b");
			_stack.Push("c");

			//Act
			var result = _stack.Peek();

			//Assert
			Assert.That(result, Is.EqualTo("c"));

		}

		[Test]
		public void Peek_StackWithObjects_DoesNotRemoveTheObjectOnTopOfTheStack()
		{
			//Arrange
			_stack.Push("a");
			_stack.Push("b");
			_stack.Push("c");

			//Act
			_stack.Peek();

			//Assert
			Assert.That(_stack.Count, Is.EqualTo(3));

		}
	}
}
