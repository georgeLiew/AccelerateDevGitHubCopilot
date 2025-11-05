using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Xunit;
using Library.Infrastructure.Data;
using Library.ApplicationCore;
using Library.ApplicationCore.Entities;
using NSubstitute;

namespace UnitTests.Infrastructure.JsonLoadRepository;

public class GetLoanTest
{
    private readonly ILoanRepository _mockLoanRepository;
    private readonly JsonLoanRepository _jsonLoanRepository;
    private readonly IConfiguration _configuration;
    private readonly JsonData _jsonData;

    public GetLoanTest()
    {
        // Build configuration for JsonData (uses default paths if appSettings.json is missing)
        _configuration = new ConfigurationBuilder().Build();

        _jsonData = new JsonData(_configuration);
        _jsonLoanRepository = new JsonLoanRepository(_jsonData);

        // Use NSubstitute to create a substitute for ILoanRepository
        _mockLoanRepository = Substitute.For<ILoanRepository>();
    }

    [Fact(DisplayName = "JsonLoanRepository.GetLoan: Returns populated loan when loan ID exists")]
    public async Task GetLoan_ReturnsLoan_WhenLoanIdExists()
    {
        // Arrange
        int existingLoanId = 1; // Use a loan ID that exists in Loans.json
        await _jsonData.EnsureDataLoaded();

        // Use _mockLoanRepository to arrange the expected loan
        var expectedLoan = _jsonData.Loans?.Find(l => l.Id == existingLoanId);
        _mockLoanRepository.GetLoan(existingLoanId).Returns(Task.FromResult(expectedLoan));

        // Act
        var actualLoan = await _jsonLoanRepository.GetLoan(existingLoanId);


        // Assert
        Assert.NotNull(expectedLoan);
        Assert.NotNull(actualLoan);
        Assert.Equal(expectedLoan.Id, actualLoan.Id);
    }

    [Fact(DisplayName = "JsonLoanRepository.GetLoan: Returns null when loan ID is not found")]
    public async Task GetLoan_ReturnsNullWhenLoanIdIsNotFound()
    {
        // Arrange
        var loanId = 999; // Use a loan ID that does not exist in the Loans.json file
        var expectedLoan = new Loan { Id = loanId, BookItemId = 101, PatronId = 202, LoanDate = DateTime.Now, DueDate = DateTime.Now.AddDays(14) };
        _mockLoanRepository.GetLoan(loanId).Returns(expectedLoan);

        // Act
        var actualLoan = await _jsonLoanRepository.GetLoan(loanId);

        // Assert
        Assert.Null(actualLoan);
    }
}
