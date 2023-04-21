
import React from 'react';
import { createRoot } from 'react-dom/client';
import { Stage, Layer, Star, Text,Rect } from 'react-konva';


function generateShapes() {
    return [...Array(10)].map((_, i) => ({
      id: i.toString(),
      x: Math.random() * window.innerWidth,
      y: Math.random() * window.innerHeight,
      rotation: Math.random() * 180,
      isDragging: false,
    }));
  }
  function generateSquares(){
    return [...Array(10)].map((_, i) => ({
        id: i.toString(),
        x: Math.random() * window.innerWidth,
        y: Math.random() * window.innerHeight,

      }));
  }
  const INITIAL_STATE = generateShapes();
  const BOARD_INITIAL_STATE = generateSquares();
function ChessBoard() {
    const [stars, setStars] = React.useState(INITIAL_STATE);
    const [squares, setSquares] = React.useState(BOARD_INITIAL_STATE);

    const handleDragStart = (e) => {
      const id = e.target.id();
      setStars(
        stars.map((star) => {
          return {
            ...star,
            isDragging: star.id === id,
          };
        })
      );
    };
    const handleDragEnd = (e) => {
      setStars(
        stars.map((star) => {
          return {
            ...star,
            isDragging: false,
          };
        })
      );
    };
  
    return (
      <Stage width={window.innerWidth} height={window.innerHeight}>
        <Layer>
          <Text text="Try to drag a star" />
          {stars.map((star) => (
            <Star
              key={star.id}
              id={star.id}
              x={star.x}
              y={star.y}
              numPoints={5}
              innerRadius={20}
              outerRadius={40}
              fill="#89b717"
              opacity={0.8}
              draggable
              rotation={star.rotation}
              shadowColor="black"
              shadowBlur={10}
              shadowOpacity={0.6}
              shadowOffsetX={star.isDragging ? 10 : 5}
              shadowOffsetY={star.isDragging ? 10 : 5}
              scaleX={star.isDragging ? 1.2 : 1}
              scaleY={star.isDragging ? 1.2 : 1}
              onDragStart={handleDragStart}
              onDragEnd={handleDragEnd}
            />
          ))}
          {/* {squares.map((square)=>(

            <Rect>
             key={square.id}
              id={square.id}
              x={square.x}
              y={square.y}
            </Rect>
          ))} */}
        </Layer>
      </Stage>
    );
}
export default ChessBoard;


// const container = document.getElementById('root');
// const root = createRoot(container);
// root.render(<App />);
