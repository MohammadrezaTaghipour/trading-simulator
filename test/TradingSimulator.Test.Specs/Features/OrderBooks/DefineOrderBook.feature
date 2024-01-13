Feature: DefineOrderBook
As a trading system architect
In order to log orders of symbols in a specific session
I want to define a order book

    Scenario: A new order book get defined with valid properties
        Given The day of week is 'Saturday' with date '2024-01-01'
        And There is a defined session with code 'session-20240101' and following properties
          | OpeningDate | ClosingDate | Code             |
          | 'Saturday'  | 'Saturday'  | session-20240101 |
        And There is a defined symbol with code 'AAPL'
        When I define a new order book with title 'order-book-20240101-AAPL' and the following info
          | Title                    | SessionCode        | Symbol |
          | order-book-20240101-AAPL | 'session-20240101' | AAPL   |
        Then I can find the defined order book with title 'order-book-20240101-AAPL' and above properties within the system