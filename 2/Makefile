SRCDIR = src
BINDIR = bin

PROG = $(BINDIR)/Program.exe

all: $(PROG)

$(PROG): $(SRCDIR)/*.cs
	mcs -out:$(PROG) $^

run: $(PROG)
	mono $<

clean:
	rm -f $(PROG)

.PHONY: all run clean
