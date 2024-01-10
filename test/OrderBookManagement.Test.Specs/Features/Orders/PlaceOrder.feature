Feature: PlaceOrder
As a Stock market trader
In order to buy or sell a Stock
I need to place order

    Background: 
        Given There is defined trader named 'Jack'

    Scenario: Order gets placed with valid properties
        Given The day of week is 'Saturday' with date '2024-01-01'
        And There is a defined session with code 'session-20240101' and following properties
          | OpeningDate | ClosingDate | Code             |
          | 'Saturday'  | 'Saturday'  | session-20240101 |
        And There is a defined symbol with code 'AAPL'
        When 'Jack' places an order with following properties
          | Session          | Symbol | CMD | Volume | Price |
          | session-20240101 | AAPL   | buy | 50     | 1000  |