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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BFSharp
{
    class Tape
    {
        private byte[] tape;
        private int position;

        /* User-defined tape size */
        private int usize;

        /* You may change this to implement larger tapes. */
        const int size = 0x10000;

        public Tape()
        {
            usize = size;
            initTape();
        }

        public Tape(int usize)
        {
            if ((this.usize = usize) == 0)
                this.usize = size;
            initTape();
        }

        private void initTape()
        {
            tape = new byte[usize];
            position = 0;
        }

        public byte get()
        {
            return tape[position];
        }

        public void set(byte value)
        {
            tape[position] = value;
        }

        public void inc()
        {
            if (tape[position] >= 255)
            {
                tape[position] = 0;
            }
            else
            {
                tape[position]++;
            }
        }

        public void dec()
        {
            if (tape[position] <= 0)
            {
                tape[position] = 255;
            }
            else
            {
                tape[position]--;
            }
        }

        public void forward()
        {
            if (position >= (usize - 1))
            {
                position = 0;
            }
            else
            {
                position++;
            }
        }

        public void reverse()
        {
            if (position <= 0)
            {
                position = (usize - 1);
            }
            else
            {
                position--;
            }
        }
    }
}
