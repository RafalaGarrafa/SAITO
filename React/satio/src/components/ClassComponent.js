import React, {Component} from 'react';

class ClassComponent extends Component{
    
    constructor(props){
        super(props);
        this.state = {
            count: 0,
        };
    }
    
    incrementCount = () => {
        this.setState({
            count: this.state.count + 1
        });
    }
    
    render(){
        return(
            <div>
                <p> Esto es un Class Component </p>
                <p> El contador tiene: {this.state.count} </p>
                <button type = "button" onClick={this.incrementCount}> picame e.e </button>

            </div>
            
        );
    }

}


export default ClassComponent;