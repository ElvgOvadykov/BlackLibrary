import React from 'react';
import WorldService from "../services/worldService";

const Worlds = () => {
    const worldService = new WorldService();
    const worlds = worldService.getWorlds();
    
    return(
        <div>
            
        </div>
    );
}

export default Worlds;