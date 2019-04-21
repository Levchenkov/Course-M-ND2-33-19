import React, { Component } from 'react';

export class Payments extends Component {
  static displayName = Payments.name;

  constructor (props) {
    super(props);
    this.state = { payments: [], loading: true };

      fetch('https://localhost:5001/api/payments')
      .then(response => response.json())
      .then(data => {
        this.setState({ payments: data.value, loading: false });
      });
  }

  static renderPaymentsTable (payments) {
    return (
      <table className='table table-striped'>
        <thead>
          <tr>
            <th>First Name</th>
            <th>Middle Name</th>
            <th>Last Name</th>
            <th>Address</th>
          </tr>
        </thead>
        <tbody>
          {payments.map(payment =>
            <tr key={payment.id}>
              <td>{payment.firstName}</td>
              <td>{payment.middleName}</td>
              <td>{payment.lastName}</td>
              <td>{payment.address}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render () {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Payments.renderPaymentsTable(this.state.payments);

    return (
      <div>
        <h1>Payments</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }
}
