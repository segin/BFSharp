/*
 * Copyright (c) 2015, Kirn Gill II <segin2005@gmail.com>
 *
 * Permission to use, copy, modify, and/or distribute this software for
 * any purpose with or without fee is hereby granted, provided that the
 * above copyright notice and this permission notice appear in all copies.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
 * WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
 * MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
 * ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
 * WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN
 * AN ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT
 * OF OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.
 */

using System;

namespace BFSharp
{
    public class Interpreter
    {
        private Tape tape;
        private int pc;
        private UserIO io;

        public Interpreter()
        {
            tape = new Tape();
            pc = 0;
        }

        public void setIO(UserIO io)
        {
            this.io = io;
        }

        public void run(String code)
        {
            String ocode = optimize(code);

            for (pc = 0; pc < ocode.Length; pc++)
            {
                switch (ocode.ToCharArray()[pc])
                {
                    case '>':
                        tape.forward();
                        break;
                    case '<':
                        tape.reverse();
                        break;
                    case '+':
                        tape.inc();
                        break;
                    case '-':
                        tape.dec();
                        break;
                    case ',':
                        tape.set(io.input());
                        break;
                    case '.':
                        io.output(tape.get());
                        break;
                    case '[':
                        if (tape.get() == 0)
                        {
                            int i = 1;
                            while (i > 0)
                            {
                                ++pc;
                                char c = ocode.ToCharArray()[pc];
                                if (c == '[')
                                    i++;
                                else if (c == ']')
                                    i--;
                            }
                        }
                        break;
                    case ']':
                        if (tape.get() != 0)
                        {
                            int i = 1;
                            while (i > 0)
                            {
                                --pc;
                                char c = ocode.ToCharArray()[pc];
                                if (c == '[')
                                    i--;
                                else if (c == ']')
                                    i++;
                            }
                        }
                        break;
                }
            }
        }

        private String optimize(String code)
        {
            String ocode = "";
            for (pc = 0; pc < code.Length; pc++)
                switch (code.ToCharArray()[pc])
                {
                    case '>':
                    case '<':
                    case ',':
                    case '.':
                    case '+':
                    case '-':
                    case '[':
                    case ']':
                        ocode += code.ToCharArray()[pc];
                        break;
                }
            return ocode;
        }


    }
}
