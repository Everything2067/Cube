# Cube
Unity application with which a cube can be controlled through serial communication.

## How to use
1. Open the application.
2. Set desired port name and baud rate and click connect.
3. Send a command. The syntax of commands are given in [Syntax](https://github.com/Everything2067/Cube/#syntax).

### Syntax
`commandSelector,value1,value2,value3<CR><LF>`
| commandSelector | value1 | value2 | value3 | Description    | Remarks                                            |
| --------------- | ------ | ------ | ------ | -------------- | -------------------------------------------------- |
| `rs`            | x-axis | y-axis | z-axis | Rotation speed | Send `rs,0,0,0` to stop rotation.                  |
| `ea`            | x-axis | y-axis | z-axis | Euler angle    | Send `ea,0,0,0` to reset the angles.               |
| `cl`            | red    | green  | blue   | Colour         | Red, green, and blue values are in the range 0-255.|


## Attributions
This project is licensed under the MIT License.

However, it includes assets made by [@dwilches](https://github.com/dwilches), which are licensed under **Creative Commons Attribution 2.0 (CC BY 2.0)**.

Original assets are available at: https://github.com/dwilches/Ardity

Per CC BY 2.0, all credits for these assets go to [@dwilches](https://github.com/dwilches).
