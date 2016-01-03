#!/usr/bin/env python

import os
from setuptools import setup, find_packages

def read(fname):
    return open(os.path.join(os.path.dirname(__file__), fname)).read()

setup(
    name = "monopoly",
    version = "0.0.1",
    author = "Zachary Stewart",
    author_email = "zachary@zstewart.com",
    description = "Monopoly core implementation",
    license = "Apache 2.0",
    url = "http://github.com/zstewar1/monopoly",
    long_description = read("README.md"),
    packages = find_packages("src"),
)
