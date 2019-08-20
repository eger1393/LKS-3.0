import React from 'react'

const SVGIcon = ({ name, style }) => {
  return <img src={require(`../../../../images/${name}.svg`)} alt={`${name}Img`} style={style}/>
}

export default SVGIcon
