install.packages("gutenbergr")
library(gutenbergr)

install.packages("tidytext")
library(tidytext)

library(dplyr)
library(stringr)

data(stop_words)

kjv <- gutenberg_download(c(10))

tidy_kjv <- kjv %>%
  mutate(linenumber = row_number(),
         chapter = cumsum(str_detect(text, regex("^chapter [\\divxlc]", 
                                                 ignore_case = TRUE)))) %>%
  ungroup() %>%
  unnest_tokens(word, text) %>%
  anti_join(stop_words)
  
tidy_kjv %>%
  count(word, sort = TRUE)
  
install.packages("ggplot2")
library(ggplot2)
  
tidy_kjv %>%
  count(word, sort = TRUE) %>%
  filter(n > 600) %>%
  mutate(word = reorder(word, n)) %>%
  ggplot(aes(word, n)) +
  geom_col() +
  xlab(NULL) +
  coord_flip()  
  
#Get all the sentiments of the nrc that are associated with joy.
nrc_joy <- get_sentiments("nrc") %>% 
  filter(sentiment == "joy")
  
#Extract the words associated with joy from the KJV by linking these words with the nrc.
tidy_kjv %>%
  inner_join(nrc_joy) %>%
  count(word, sort = TRUE)

library(tidyr)

kjv_sentiment <- tidy_kjv %>%
  inner_join(get_sentiments("bing")) %>%
  count(index = linenumber %/% 80, sentiment) %>%
  spread(sentiment, n, fill = 0) %>%
  mutate(sentiment = positive - negative)

ggplot(kjv_sentiment, aes(index, sentiment)) +
  geom_col(show.legend = FALSE) 
  