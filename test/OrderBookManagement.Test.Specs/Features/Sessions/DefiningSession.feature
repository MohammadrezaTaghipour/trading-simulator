Feature: Defining session
As a trading system architect
In order to log orders of a symbol
I want to define a session

    Scenario: A new session gets defined with valid properties
        Given The day of week is 'Saturday' with date '2024-01-01'
        When I define a session with code 'session-20240101' and with following properties
          | OpeningDate | ClosingDate | Code             |
          | 'Saturday'  | 'Saturday'  | session-20240101 |
        Then I can find the defined session with code 'session-20240101' and above properties within the system