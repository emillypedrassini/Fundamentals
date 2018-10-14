using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TestNinja.Mocking;
using TestNinja.Mocking.Interface;

namespace TestNinja.UnitTest.Mocking
{
	[TestFixture]
	public class HousekeeperServiceTests
	{
		private HousekeeperService _service;
		private Mock<IUnitOfWorkRepository> _unitOfWorkMock;
		private Mock<IStatementGenerator> _statementGeneratorMock;
		private Mock<IEmailService> _emailServiceMock;
		private Mock<IXtraMessageBox> _xtraMessageBoxMock;
		private DateTime _statementDate = new DateTime(2018, 1, 1);
		private Housekeeper _houseKeeper;
		private string _statementFileName;

		[SetUp]
		public void SetUp()
		{
			_houseKeeper = new Housekeeper
			{
				Email = "a",
				FullName = "b",
				Oid = 1,
				StatementEmailBody = "c"
			};

			_unitOfWorkMock = new Mock<IUnitOfWorkRepository>();
			_unitOfWorkMock.Setup(ouw => ouw.Query<Housekeeper>()).Returns(new List<Housekeeper>
			{
				_houseKeeper
			}.AsQueryable());

			_statementFileName = "fileName";
			_statementGeneratorMock = new Mock<IStatementGenerator>();
			_statementGeneratorMock
				.Setup(sg => sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, _statementDate))
				.Returns(() => _statementFileName);

			_emailServiceMock = new Mock<IEmailService>();
			_xtraMessageBoxMock = new Mock<IXtraMessageBox>();

			_service = new HousekeeperService(
				_unitOfWorkMock.Object,
				_statementGeneratorMock.Object,
				_emailServiceMock.Object,
				_xtraMessageBoxMock.Object);

		}

		[Test]
		public void SendStatementEmails_WhenCalled_GenerateStatement()
		{
			//Arrange

			//Act
			_service.SendStatementEmails(_statementDate);

			//Assert
			_statementGeneratorMock.Verify(sg =>
				sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, _statementDate));

		}

		[Test]
		public void SendStatementEmails_HousekeepersEmailIsNull_ShouldNotGenerateStatement()
		{
			//Arrange
			_houseKeeper.Email = null;

			//Act
			_service.SendStatementEmails(_statementDate);

			//Assert
			_statementGeneratorMock.Verify(sg =>
				sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, _statementDate),
				Times.Never);

		}

		[Test]
		public void SendStatementEmails_HousekeepersEmailIsWhiteSpace_ShouldNotGenerateStatement()
		{
			//Arrange
			_houseKeeper.Email = " ";

			//Act
			_service.SendStatementEmails(_statementDate);

			//Assert
			_statementGeneratorMock.Verify(sg =>
				sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, _statementDate),
				Times.Never);

		}

		[Test]
		public void SendStatementEmails_HousekeepersEmailIsEmpty_ShouldNotGenerateStatement()
		{
			//Arrange
			_houseKeeper.Email = string.Empty;

			//Act
			_service.SendStatementEmails(_statementDate);

			//Assert
			_statementGeneratorMock.Verify(sg =>
				sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, _statementDate),
				Times.Never);

		}

		[Test]
		public void SendStatementEmails_WhenCalled_EmailTheStatement()
		{
			//Arrange
			//_statementGeneratorMock
			//	.Setup(sg => sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, _statementDate))
			//	.Returns(_statementFileName);

			//Act
			_service.SendStatementEmails(_statementDate);

			//Assert
			VerifyEmailSent();

		}

		[Test]
		public void SendStatementEmails_StatementFileNameIsNull_ShouldNotEmailTheStatement()
		{
			//Arrange
			_statementFileName = null;

			//Act
			_service.SendStatementEmails(_statementDate);

			//Assert
			VerifyEmailNotSent();
		}

		[Test]
		public void SendStatementEmails_StatementFileNameIsEmptyString_ShouldNotEmailTheStatement()
		{
			//Arrange
			_statementFileName = string.Empty;

			//Act
			_service.SendStatementEmails(_statementDate);

			//Assert
			VerifyEmailNotSent();
		}

		[Test]
		public void SendStatementEmails_StatementFileNameIsWhiteSpace_ShouldNotEmailTheStatement()
		{
			//Arrange
			_statementFileName = " ";

			//Act
			_service.SendStatementEmails(_statementDate);

			//Assert
			VerifyEmailNotSent();
		}

		[Test]
		public void SendStatementEmails_EmailSendingFails_DisplayAMessageBox()
		{
			//Arrange
			_emailServiceMock.Setup(es => es.EmailFile(
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<string>()
			)).Throws<Exception>();

			//Act
			_service.SendStatementEmails(_statementDate);

			//Assert
			_xtraMessageBoxMock.Verify(mb => 
				mb.Show(It.IsAny<string>(), It.IsAny<string>(), MessageBoxButtons.OK));
		}

		private void VerifyEmailNotSent()
		{
			_emailServiceMock.Verify(es => es.EmailFile(
					It.IsAny<string>(),
					It.IsAny<string>(),
					It.IsAny<string>(),
					It.IsAny<string>()),
				//es.EmailFile(_houseKeeper.Email, _houseKeeper.StatementEmailBody, _statementFileName, It.IsAny<string>()),
				Times.Never);
		}

		private void VerifyEmailSent()
		{
			_emailServiceMock.Verify(es => es.EmailFile(
				_houseKeeper.Email,
				_houseKeeper.StatementEmailBody,
				_statementFileName,
				It.IsAny<string>())
			);
		}

	}
}
