function ElyseCore(commands, callback) {
    var _self = this;
    var _cmds = commands;
    var _pc = -1;
    var _callback = callback;

    function parallel(commands, callback) {
        var wait = commands.length;
        for (var pc = 0; pc < commands.length; ++pc) {
            var c = commands[pc];
            if (c[0] instanceof Array) {
                new ElyseCore(c, function () { if (--wait === 0 && callback) callback(); }).run();
            }
            else {
                c[2].push(function () { if (--wait === 0 && callback) callback(); });
                c[0][c[1]].apply(c[0], c[2]);
            }
        }
    }

    this.run = function () {
        if (++_pc >= _cmds.length) {
            if (_callback) _callback();
            _callback = null;
            return;
        }
        var c = _cmds[_pc];
        if (c[0] instanceof Array) {
            parallel(c, function () { _self.run(); });
        }
        else
        {
            c[2].push(function () { _self.run(); });
            c[0][c[1]].apply(c[0], c[2]);
        }
    }
}