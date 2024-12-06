# Credit Payment System

This repository contains the implementation of a credit payment system for an enterprise. The enterprise offers two payment options for its customers, each governed by specific rules and conditions.

## Payment Options

The enterprise provides the following payment methods:

1. **Immediate**: Customers make the payment immediately.
2. **Credit**: Customers can make the payment later, subject to additional interest.

## Credit Eligibility Conditions

To avail of the credit option, customers must satisfy one of the following conditions:
- **Long-term customer**: The customer has been doing business with the enterprise for more than 24 months.

## Interest Rates for Credit

Interest is applied to the invoice amount based on the duration from the invoice date to the current date as follows:

| Duration                     | Interest Rate |
|------------------------------|---------------|
| Duration ≤ 14 days           | 4%            |
| 14 days < Duration ≤ 30 days | 6%            |
| 30 days < Duration ≤ 60 days | 10%           |
| 60 days < Duration ≤ 180 days| 16%           |
| Duration > 180 days          | 20%           |

## Payment Handling for Outstanding Credits

When a customer with an outstanding credit makes a payment:
- The earliest outstanding amount is reduced first.

## Development Notes

- This repository focuses on **business logic**, **design**, **test cases**, and **extension points**.
- **UI considerations** are not within the scope of this implementation.

## How to Use

1. Clone the repository:
   ```bash
   git clone https://github.com/imparthibank/clean-architecture.git
