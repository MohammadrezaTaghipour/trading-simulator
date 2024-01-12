Feature: DefiningSymbol
As a trading system architect
In order to represent the companies' Shares in the stock market
I need to define a unique symbol for each one

    Scenario: A new symbol gets defined with valid properties
        When I define a new symbol with code 'AAPL'
        Then I can find the defined symbol with code 'AAPL' within the system