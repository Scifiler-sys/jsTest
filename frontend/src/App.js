import './App.css';
import { useState, useEffect } from 'react';

function App() {
  const [data, setData] = useState([]);

  useEffect(() => {
    //Change api fetching to the right location
    fetch("http://pokemonapireston-env.eba-3kaqziuz.us-east-1.elasticbeanstalk.com:5001/WeatherForecast")
      .then(response => response.json())
      .then(weathers => {
        // console.log(weathers);
        setData((previous) => weathers)
      })
  }, [])

  return (
    <div className="App">
      <ul>
        {
          data.map((weather, i) => <li key={i}> {weather.summary} </li>)
        }
      </ul>
    </div>
  );
}

export default App;
