import React from 'react';
import './main.css'

const Home = () => {
    return (
        <div className="main">
            <h2>Добро пожаловать на Warhammer 40000 Wiki Ovadykov Edition.</h2>
            <img src="../../../public/image/Warhammer-40k.jpg" alt="Warhammer" width="1920" height="960"/>
            <p>Приветствуем вас в сообществе Warhammer 40k Вики.
                Наша основная задача — качественное, понятное и красочное предоставление информации о вселенной
                Warhammer 40k.
                Присоединяйтесь к нам и поспособствуйте пополнению информации базы данных!</p>
        </div>
    );
}

export default Home;