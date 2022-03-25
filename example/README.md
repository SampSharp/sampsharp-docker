Docker example
==============

### Building
```
docker build . -t testserver
```

### Running

```
docker run --rm -it -p 7777:7777/udp testserver
```

### Quircks
- SampSharp's default filterscripts and gamemode are not installed with the plugin through sampctl, so they're included in the image manually for now. In the future, the SampSharp plugin will automatically write these modes into the corresponding directories if they could not be found.
- SampSharp performs a check on the configured pawn gamemodes by default. It checks for a line containing `gamemode0 empty 1`, but sampctl generates the line `gamemode0 empty` (without the 1). Normally SampSharp wouldn't start in this situation. We work around this for now with the `skip_empty_check true` option.