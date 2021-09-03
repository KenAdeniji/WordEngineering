REM 2021-08-31 https://www.ledger-cli.org/3.0/doc/ledger3.html
E:\Accounting\dmitry-merzlyakov\nledger\Source\NLedger.CLI\bin\Release\net45\NLedger-cli.exe -f drewr3.dat balance
E:\Accounting\dmitry-merzlyakov\nledger\Source\NLedger.CLI\bin\Release\net45\NLedger-cli.exe -f drewr3.dat register Expenses
REM 2021-09-01
E:\Accounting\dmitry-merzlyakov\nledger\Source\NLedger.CLI\bin\Release\net45\NLedger-cli.exe -f drewr3.dat register payee "Organic"
REM 2021-09-02T09:54:00 The combined total of your Assets and Liabilities is your net worth. So to see your current net worth, use this command: 
E:\Accounting\dmitry-merzlyakov\nledger\Source\NLedger.CLI\bin\Release\net45\NLedger-cli.exe -f drewr3.dat balance ^assets ^liabilities
REM 2021-09-02T10:03:00 Current cash flow. In a similar vein, your Income accounts show up negative, because they transfer money from an account in order to increase your assets. Your Expenses show up positive because that is where the money went to. The combined total of Income and Expenses is your cash flow. A positive cash flow means you are spending more than you make, since income is always a negative figure
E:\Accounting\dmitry-merzlyakov\nledger\Source\NLedger.CLI\bin\Release\net45\NLedger-cli.exe -f drewr3.dat balance ^income ^expenses
REM 2021-09-02T10:10:00 How much do I spend each month on X? Ledger provides a simple way of displaying monthly totals for any account. Here is an example that summarizes your monthly automobile expenses:
E:\Accounting\dmitry-merzlyakov\nledger\Source\NLedger.CLI\bin\Release\net45\NLedger-cli.exe -M register -f drewr3.dat expenses:auto
