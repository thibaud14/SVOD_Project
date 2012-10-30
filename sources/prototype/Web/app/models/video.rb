class Video < ActiveRecord::Base
  attr_accessible :bo_url, :country, :duration, :position, :season, :synopsis, :tagline, :thumbnail_url, :title, :type, :video_url, :year

  belongs_to :ref_star_ratings


  has_many :video_people
  has_many :people, :through => :video_people

  has_many :video_review
  has_many :user, :through => :video_review

  has_many :video_watched
  has_many :user, :through => :video_watched

  has_many :video_genres
  has_many :ref_video_genres, :through => :video_genres

  has_many :video_subtitles
  has_many :ref_video_subtitles, :through => :video_subtitles

  has_many :video_langue
  has_many :ref_video_langue, :through => :video_langue

  belongs_to :collection



end
