import React, { Component } from 'react';

export class AddPayment extends Component {
    static displayName = AddPayment.name;

    constructor(props) {
        super(props);
        this.state = { loading: true };


        this.state = { loading: false };
    }


    render () {
        let contents = this.state.loading  
            ? <p><em>Loading...</em></p>
            : AddPayment.renderCreateForm(); 

        return (
            <div>
                <h1>New payment</h1>
                <p>This component demonstrates validating and adding new Payment to the server.</p>
                <h3>Payment</h3>  
                <hr />
                {contents}
            </div>
        );
    }

    handleCancel(e) {
        e.preventDefault();
    }

    static renderCreateForm() {
        return (
            <form onSubmit={this.handleSave}>
                <div className="form-group row" >  
                    <input type="hidden" name="Id" value={this.state.empData.employeeId} />  
                </div>
                <div class="form-group">
                    <label class="control-label col-md-2"></label>
                    <div class="col-md-10">
                        <input asp-for="Title" class="form-control" />
                        <span asp-validation-for="Title" class="text-danger"></span>
                    </div>
                </div>

                <div className="form-group row" >  
                    <label className=" control-label col-md-12" htmlFor="Name">Name</label>  
                    <div className="col-md-4">  
                        <input className="form-control" type="text" name="name" defaultValue={this.state.empData.name} required />  
                    </div>  
                </div >

                <p>Test</p>
                <div className="form-group">  
                    <button type="submit" className="btn btn-default">Save</button>  
                    <button className="btn" onClick={this.handleCancel}>Cancel</button>  
                </div > 
            </form> 
            );
        }

}

export class PaymentData {
    id: number = 0;

}
